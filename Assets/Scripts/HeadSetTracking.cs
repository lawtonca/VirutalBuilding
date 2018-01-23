using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	This script is to be attached to the StreamVr controller's Eye component.
	It will record the headset's position, velocity, and how far it has travel.
	The HowOftenToUpdate variable is used to change how often the position, velocity, and distance traveled is updated
	Once the program is shutdown it will automatically print these recorded values to a CSV file with the format Position.X,Position.Y,Velocity,Distance
	The file will be located at Project/Results/Today's Date/ the file name is the number of files in the folder + 1, IE 3 files, new file is named 4.csv
*/
public class HeadSetTracking : MonoBehaviour {
	public List<Vector3> Locations = new List<Vector3>();
    public List<float> Velocities = new List<float>();
    public List<float> Distances = new List<float>();
	float timeSinceLastRecord = 0;
	float HowOftenToUpdate = (float) .5;
    #region Engine Functions
    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRecord += Time.deltaTime;
        if (timeSinceLastRecord >= HowOftenToUpdate)
        {
            timeSinceLastRecord -= HowOftenToUpdate;
            SaveHeadsetLocations();
            SaveVelAndDist(Locations.Count - 1, Locations.Count - 2);
        }

    }

    ///<summary>
    ///This method is called when the Application exits
    ///Writes the locations, and velocities and distances between the two closest locations
    ///Creates a directory named Results\'today's date' if one doesn't exist
    ///Writes the data to a file named 'the num of files in the directory'.csv
    /// </summary>

    private void OnApplicationQuit()
    {
        //get directory and file name for today
        string dir = System.IO.Directory.GetCurrentDirectory();
	    string date = System.DateTime.Today.ToString("d");

        //convert '/' to '-' because '/' represents directory change
        date = date.Replace("/", "-");

        //make directory location Game/Results/today
		dir += @"\Results\" + date.Replace("d", "0");

        //make sure the file for today exists
        if (!System.IO.Directory.Exists(dir))
        {
            System.IO.Directory.CreateDirectory(dir);
        }

        //get file name based today's date and the number of files in that folder
        int count = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly).Length + 1;
        dir += @"\" + count;
        writeToFile(dir + ".csv");
    }
    #endregion

    #region Value Recording
    /// <summary>
    ///  Records the current location of the headset
    ///  Is updated when the HowOfterToUpdate value has been based.
    /// </summary>
    void SaveHeadsetLocations()
    {
            //save the current location of the headset
            Vector3 loc = transform.position;
            Locations.Add(loc);
    }

    /// <summary>
    /// This method records the velocity and distance traveled between two points
    /// </summary>
    /// <param name="firstIndex"> the index in the Locations array that the first vector can be found</param>
    /// <param name="secondIndex">the index in the Locations array that the second vector can be found</param>

    void SaveVelAndDist(int firstIndex, int secondIndex)
    {
        //save the distance and velocity between these two points, the first vector being Locations[firstIndex] and the second vector being Locations[secondLocation]
        Distances.Add(CalculateDistance(Locations[firstIndex], Locations[secondIndex]));
        Velocities.Add(CalculateVelocity(Locations[firstIndex], Locations[secondIndex], HowOftenToUpdate));
    }

    /// <summary>
    /// Calculates the distance between the two vectors, will return 0 if either vector is null
    /// </summary>
    /// <param name="start">The vector that will be considered the starting point</param>
    /// <param name="end">The vector that will be considered the ending point</param>
    /// <returns>Returns the distance between these two vectors
    /// If either vector is null returns 0</returns>
    float CalculateDistance(Vector3? start, Vector3? end)
    {
        float distance = 0;

        //find the distance between the two vectors if both are valid
        if (IsBothVectorsValid(start, end))
        {
            distance = Vector3.Distance((Vector3) start, (Vector3) end);
        }

        return distance;
    }

     /// <summary>
     /// Returns the velocity required to travel the distance between the start point and end point based on the time taken
     /// </summary>
     /// <param name="start">The vector that will be considered the starting point</param>
     /// <param name="end">The vector that will be considered the ending point</param>
     /// <param name="time">The time in seconds taken to travel betweent the start and end points
     /// Default will be .5 seconds</param>
     /// <returns></returns>
    float CalculateVelocity(Vector3? start, Vector3? end, float time = (float) .5)
    {
        //return the velocity taken to move between start and end points
        return CalculateDistance(start, end) / time;
    }

    /// <summary>
    /// Determines if both vectors are valid and not null
    /// </summary>
    /// <param name="point1">The first vector to be checked for null value</param>
    /// <param name="point2">The seconds vector to be checked for null value</param>
    /// <returns>Boolean- True if both vectors are not null value, False if either vector is a null value </returns>
    bool IsBothVectorsValid(Vector3? point1, Vector3? point2)
    {
        return point1 != null && point2 != null;
    }

    #endregion


    #region File Writing
    /// <summary>
    /// Converts all of the recorded locations, velocities, and distances into a string
    /// In the format location.x,location.y,velocity,distance\n
    /// </summary>
    /// <returns>Returns the concatinated string of all the locations, velocities, and distances recorded</returns>
    override public string ToString()
    {
        //Concatinates the string of the file based on the locations, velocities, and distances
        string message = "";
        for (int i = 0; i < Velocities.Count; i++)
        {
            message += Locations[i].x + "," + Locations[i].y + "," + Velocities[i] + "," + Distances[i] + System.Environment.NewLine;
        }

        return message;
    }

    /// <summary>
    /// Writes the ToString to the file based on the name and directory passed into the paramters
    /// </summary>
    /// <param name="filename">String for the directory and file name of the file to be written</param>
    void writeToFile(string filename)
    {
        //writes the ToString to the file
        System.IO.File.WriteAllText(@filename, ToString());
    }
    #endregion

}


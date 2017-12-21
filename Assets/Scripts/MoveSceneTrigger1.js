#pragma strict

function OnTriggerEnter (Col : Collider) 
{
   if(Col.tag == "Player")
   {
   Application.LoadLevel ("GoodFile28BJune2017");
  }
}
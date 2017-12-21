#pragma strict

function OnTriggerEnter (Col : Collider) 
{
   if(Col.tag == "Player")
   {
   Application.LoadLevel ("GoodFile17BJuly2017BenchRoom");
  }
}
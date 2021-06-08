
using System;
using System.Collections;
class HelloWorld {
  static void Main() {
     Player A=new Player("A",0);
	 Player B=new Player("B",0);
	 Game g=new Game(A,B);
	 ArrayList al=g.startGame();
	 Console.WriteLine("winner: "+al[3]);
  } 
}

class Player{
    public string name;
    public int score;
    public bool bat;
    public int gamesWon;
    public Random random;
    public Player(String name,int score){
        this.name=name;
        this.score=score;
        this.bat=false;
        this.gamesWon=0;
        this.random = new Random();
    }
    public int getGesture(){
        
        return random.Next(7);
    }
}
class Game{
    public Player player1,player2;
    public Game(Player player1,Player player2){
        this.player1=player1;
        this.player2=player2;
        determine();
    }
    public void determine(){
        Console.WriteLine("Player1 choice of toss");
        String player1toss=Console.ReadLine();
        Console.WriteLine("Player2 choice of toss");
        String player2toss=Console.ReadLine();
        String tossAns=toss();
        if(player1toss.Equals(tossAns)){
            Console.WriteLine("batting or bowling for player1");
            String choice=Console.ReadLine();
            if(choice.Equals("batting")){
                player1.bat=true;
            }
            else{
                player2.bat=true;
            }
        }
        else{
            Console.WriteLine("batting or bowling for player2");
            String choice=Console.ReadLine();
            if(choice.Equals("batting")){
                player2.bat=true;
            }
            else{
                player1.bat=true;
            }
        }
    }
    public String toss(){
        Random rand=new Random();
        int random=rand.Next(2);
        if(random==1)
        return "head";
        return "tail";
    }
    public ArrayList startGame(){
        ArrayList al=new ArrayList(4);//round 1,2,3 and winner;
        Player bat=(player1.bat)?player1:player2;
        Player bowl=(!player1.bat)?player1:player2;
        Console.WriteLine("Batsman score Bowler score");
        for(int round=0;round<3;++round){
            int outc=0;
            Console.WriteLine("Round "+(round+1));
            bat.score=0;
            bowl.score=0;
            int gestures;
            for(gestures=0;gestures<15;++gestures){
            int batScore=bat.getGesture();
            int bowlScore=bowl.getGesture();
            Console.WriteLine(bat.name+" "+batScore+" "+bowl.name+" "+bowlScore);
            if(batScore!=bowlScore){
                    bat.score+=batScore;
                    if(outc==1&&bat.score>bowl.score){
                        break;
                    }
                }
            else{
                Console.WriteLine(bat.name+" got out scoring "+bat.score);
                outc++;
                if(outc==2){
                    break;
                }
                Player temp=bat;
                bat=bowl;
                bowl=temp;
                
            }
            Console.WriteLine("---------------");
            }
            if(gestures==15){
                Console.WriteLine("Turns over");
                Console.WriteLine(bat.name+" scored "+bat.score);
                if(outc==1){
                    Player temp=bat;
                    bat=bowl;
                    bowl=temp;
                }
            }
            if(bat.score>bowl.score){
                bat.gamesWon++;
                al.Add(bat.name);
                Console.WriteLine("Round "+(round+1)+" winner is "+bat.name);
            }
            else if(bat.score<bowl.score){
                bowl.gamesWon++;
                al.Add(bowl.name);
                Console.WriteLine("Round "+(round+1)+" winner is "+bowl.name);

            }
            else{
                al.Add("tie");
                Console.WriteLine("Round "+(round+1)+" is tie");
            }
           if(bat.gamesWon>=2){
             	if(round==1){
             	        Console.WriteLine("No final round conducted because winner is already determined");
             		    al.Add("No final round conducted because winner is already determined");
             	}
                al.Add(bat.name);
             	return al;	
       	    }
        	else if(bowl.gamesWon>=2){
        	    if(round==1){
        	           Console.WriteLine("No final round conducted because winner is already determined");
             		    al.Add("No final round conducted because winner is already determined");
             	}
                al.Add(bowl.name);
                return al;
       		}
            
        }
        al.Add("tie");
        return al;
    }
}






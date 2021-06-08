
using System;
using System.Collections;
class HelloWorld {
  static void Main() {
     Console.WriteLine("Enter no of floors");
        int noOfFloors=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter no of Main Corridors");
        int noOfMainCorridors=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter no of SubCorridors");
        int noOfSubCorridors=Convert.ToInt32(Console.ReadLine());
        Hotel temp=new Hotel(noOfFloors,noOfMainCorridors,noOfSubCorridors);
        temp.printFloors();
        while(true) {
        Console.WriteLine("Sub corridor 1)movement 2)Nomovement in 1 minute 3)exit");
        int action=Convert.ToInt32(Console.ReadLine());
        	if(action==1) {
        		Console.WriteLine("Enter floor number");
        		int floor=Convert.ToInt32(Console.ReadLine());
        		Console.WriteLine("Enter subcorridor number");
        		int subCorridor=Convert.ToInt32(Console.ReadLine());
        		temp.movementInSubCorriodor(floor,subCorridor);
        		temp.printFloors();
        	}
        	else if(action==2) {
        		Console.WriteLine("Enter floor number");
        		int floor=Convert.ToInt32(Console.ReadLine());
        		Console.WriteLine("Enter subcorridor number");
        		int subCorridor=Convert.ToInt32(Console.ReadLine());
        		temp.NomovementInSubCorriodor(floor,subCorridor);
        		temp.printFloors();
        	}
        	else {
        		break;
        	}
        }
  }
}

class ElectronicBuilder{

    public static readonly string LIGHT = "Light";
    public static readonly string AC = "Ac";

    public static ArrayList getSubCorridorDevices() {
        ArrayList equipment=new ArrayList();
        equipment.Add(new ElectronicEquipment(LIGHT, 5, false));
        equipment.Add(new ElectronicEquipment(AC, 10, true));
        return equipment;
    }

    public static ArrayList getCorridorDevices() {
        ArrayList equipment=new ArrayList();
        equipment.Add(new ElectronicEquipment(LIGHT, 5, true));
        equipment.Add(new ElectronicEquipment(AC, 10, true));
        return equipment;
    }
}

class ElectronicEquipment {
    public string type;
    public int units;
    public bool on;

    public ElectronicEquipment(string type, int units, bool on) {
        this.type = type;
        this.units = units;
        this.on = on;
    }

    public int getUnits() {
        return on ? units : 0;
    }

    void switchIt(bool on) {
        this.on = on;
    }

    public bool isOn() {
        return on;
    }

    public bool isOff() {
        return !on;
    }

    public string getType() {
        return type;
    }
}
class Corridor  {

    public Hashtable electronicEquipmentMap;
    public Corridor(ArrayList equipments) {
    	electronicEquipmentMap=new Hashtable();
        foreach(ElectronicEquipment temp in equipments) {
        	electronicEquipmentMap.Add(temp.getType(), temp);
        }
    }

  

    public int getTotalPowerConsumption() {
    	int totalPower=0;
        foreach(ElectronicEquipment temp in electronicEquipmentMap.Values) {
        	totalPower+=temp.getUnits();
        }
        return totalPower;
    }
}
class Floor {
    private  ArrayList corridors;
    private  ArrayList subCorridors;

    public Floor(int numberOfMainCorridors, int numberOfSubCorridors) {
        corridors = new ArrayList();
        for(int corridorIndex=0;corridorIndex<numberOfMainCorridors;corridorIndex++) {
            corridors.Add(new Corridor(ElectronicBuilder.getCorridorDevices()));
        }
        subCorridors = new ArrayList();
        for(int subCorridorIndex=0; subCorridorIndex<numberOfSubCorridors;subCorridorIndex++) {
            subCorridors.Add(new SubCorridor(ElectronicBuilder.getSubCorridorDevices()));
        }
    }

    public ArrayList getCorridors() {
        return corridors;
    }

    public ArrayList getSubCorridors() {
        return subCorridors;
    }
    public void printCorridors() {
    	int corridorCount=1;
    	foreach(Corridor temp in corridors) {
    		Console.WriteLine("Main corridor "+corridorCount);
    		string li=((ElectronicEquipment)temp.electronicEquipmentMap["Light"]).isOn()?"On":"Off";
    		Console.WriteLine("Light "+li);
    		string ac=((ElectronicEquipment)temp.electronicEquipmentMap["Ac"]).isOn()?"On":"Off";
    		Console.WriteLine("Ac "+ac);
    		corridorCount++;
    	}
    }
    public void printSubCorridors() {
    	int subcorridorCount=1;
    	foreach(SubCorridor temp in subCorridors) {
    		Console.WriteLine("Sub corridor "+subcorridorCount);
    		string li=((ElectronicEquipment)temp.electronicEquipmentMap["Light"]).isOn()?"On":"Off";
    		Console.WriteLine("Light "+li);
    		string ac=((ElectronicEquipment)temp.electronicEquipmentMap["Ac"]).isOn()?"On":"Off";
    		Console.WriteLine("Ac "+ac);
    		subcorridorCount++;
    	}
    }
    
    public int totalPowerConsumption() {
      
        int totalPower=0;
        foreach(Corridor temp in corridors) {
        	totalPower+=temp.getTotalPowerConsumption();
        }
        foreach(SubCorridor temp in subCorridors) {
        	totalPower+=temp.getTotalPowerConsumption();
        }
        return totalPower;
        
    }
}
class Hotel{

    private ArrayList floors;
    private int numberOfFloors, numberOfMainCorridors, numberOfSubCorridors;
    public Hotel(int numberOfFloors, int numberOfMainCorridors, int numberOfSubCorridors) {
    	this.numberOfFloors=numberOfFloors;
    	this.numberOfMainCorridors=numberOfMainCorridors;
    	this.numberOfSubCorridors=numberOfSubCorridors;
        floors = new ArrayList();
        for(int floorIndex=0;floorIndex<numberOfFloors;floorIndex++) {
            floors.Add(new Floor(numberOfMainCorridors, numberOfSubCorridors));
        }
    }

    public ArrayList getFloors() {
        return floors;
    }
    public void printFloors() {
    	int n=floors.Count;
        Console.WriteLine(n);
    	for(int floorcount=0;floorcount<n;floorcount++) {
    		Console.WriteLine("Floor "+(floorcount+1));
    		Floor temp=(Floor)floors[floorcount];
    		Floor temp2=(Floor)floors[floorcount];
    		temp.printCorridors();
    		temp2.printSubCorridors();
    	}
    }

	public void movementInSubCorriodor(int floor, int subCorridor) {
		Floor fl=(Floor)floors[floor-1];
		ArrayList sub=fl.getSubCorridors();
		SubCorridor movement=(SubCorridor)sub[subCorridor-1];
		((ElectronicEquipment)movement.electronicEquipmentMap["Light"]).on=true;
		int power=fl.totalPowerConsumption();
			for(int i=0;i<sub.Count&&power>limit();i++) {
				if(i==(subCorridor-1)&&sub.Count!=1) {
					continue;
				}
				else {
					SubCorridor change=(SubCorridor)sub[i];
					((ElectronicEquipment)change.electronicEquipmentMap["Ac"]).on=false;
				}
				power=fl.totalPowerConsumption();
			}
	}
	public int limit() {
		return numberOfMainCorridors*15+numberOfSubCorridors*10;
	}
	public void NomovementInSubCorriodor(int floor, int subCorridor) {
		Floor fl=(Floor)floors[floor-1];
		ArrayList sub=fl.getSubCorridors();
		SubCorridor movement=(SubCorridor)sub[(subCorridor-1)];
		((ElectronicEquipment)movement.electronicEquipmentMap["Light"]).on=false;
		int power=fl.totalPowerConsumption();
			for(int i=0;i<sub.Count&&power<limit();i++) {
				if(i==(subCorridor-1)&&sub.Count!=1) {
					continue;
				}
				else {
					SubCorridor change=(SubCorridor)sub[i];
					((ElectronicEquipment)change.electronicEquipmentMap["Ac"]).on=true;
				}
				power=fl.totalPowerConsumption();
			}
		
	}
}
class SubCorridor  {
    public Hashtable electronicEquipmentMap;

    public SubCorridor(ArrayList equipments) {
    	electronicEquipmentMap=new Hashtable();
        foreach(ElectronicEquipment temp in equipments) {
        	electronicEquipmentMap.Add(temp.getType(), temp);
        }    }

    public int getTotalPowerConsumption() {
    	int totalPower=0;
        foreach(ElectronicEquipment temp in electronicEquipmentMap.Values) {
        	totalPower+=temp.getUnits();
        }
        return totalPower;
    }

    
}




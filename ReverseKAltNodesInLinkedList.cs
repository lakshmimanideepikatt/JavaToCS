
using System;
using System.Collections;
class Node{
    public int data;
    public Node next;
    public Node(int data){
        this.data=data;
        next=null;
    }
}
class LinkedList{
    Node root;
    public void add(int val){
        if(root==null){
            root=new Node(val);
        }
        else{
            Node temp=root;
            root=new Node(val);
            root.next=temp;
        }
    }
    public Node reverseK(int k, Node head){
        if(head==null)
            return null;
        Node temp,next,prev;
        temp=head;
        int count=0;
        while(temp!=null){
            next=temp.next;
            temp.next=prev;
            temp=next;
            count++;
            if(count==k)
                break;
        }
        int nextcount=0;
        head.next=temp;
        while(temp!=null&&nextcount<k){
            temp=temp.next;
        }
        if(temp!=null)
        temp.next=reverseK(k,temp);
        return prev;
    }
    public void print(Node head){
        Node temp=head;
        while(temp!=null){
            Console.Write(temp.val+"->");
            temp=temp.next;
        }
        Console.WriteLine("null");
    }
}
public class Main
{
	public static void main(String[] args) {
		LinkedList ll=new LinkedList();
		ll.add(9);
		ll.add(8);
		ll.add(7);
		ll.add(6);
		ll.add(5);
		ll.add(4);
		ll.add(3);
		ll.add(2);
		ll.add(1);
		ll.print(ll.root);
		ll.print(ll.reverseK(3,ll.root));
	}
}


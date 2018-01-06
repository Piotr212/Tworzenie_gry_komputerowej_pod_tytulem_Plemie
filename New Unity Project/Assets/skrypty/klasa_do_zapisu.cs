using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class klasa_do_zapisu {
	public string nazwa_sceny;//przechowuje ciąg znaków
	public dane_postaci postaci;//przechowuje dane z struktury dane_postaci
	public List<dane_wojownika> wojownik=new List<dane_wojownika>();//przechowuje liste danych z struktury dane_wojownika
	public List<dane_uzdrowiciela> uzdrowiciel=new List<dane_uzdrowiciela>();//przechowuje liste danych z struktury dane_uzdrowiciela
	public List<dane_robotnik> robotnik=new List<dane_robotnik>();//przechowuje liste danych z struktury dane_robotnik
	public List<dane_chat> chata=new List<dane_chat>();//przechowuje liste danych z struktury dane_chat
	public List<dane_drzew> drzewa=new List<dane_drzew>();//przechowuje liste danych z struktury dane_drzew
	public dane_GameMaster GameMaster;//przechowuje dane z struktury dane_GameMaster
	public List<dane_zadań> zadania=new List<dane_zadań>();//przechowuje liste danych z struktury dane_zadań
	public struct dane_postaci
	{
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public int grupa;//przechowuje liczbę naturalną
		public int nr_oddziału;//przechowuje liczbę naturalną
		public int stan_życia;//przechowuje liczbę naturalną
		public int stan_many;//przechowuje liczbę naturalną
	}
	public struct dane_wojownika
	{
		public string tag;//przechowuje ciąg znaków
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public int grupa;//przechowuje liczbę naturalną
		public int nr_oddziału;//przechowuje liczbę naturalną
		public int stan_życia;//przechowuje liczbę naturalną
		public float cel_x;//przechowuje liczbę rzeczywistą
		public float cel_y;//przechowuje liczbę rzeczywistą
		public float cel_z;//przechowuje liczbę rzeczywistą
		public string nowy_cel;//przechowuje ciąg znaków
	}
	public struct dane_uzdrowiciela
	{
		public string tag;//przechowuje ciąg znaków
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public int grupa;//przechowuje liczbę naturalną
		public int nr_oddziału;//przechowuje liczbę naturalną
		public int stan_życia;//przechowuje liczbę naturalną
		public int stan_many;//przechowuje liczbę naturalną
		public float cel_x;//przechowuje liczbę rzeczywistą
		public float cel_y;//przechowuje liczbę rzeczywistą
		public float cel_z;//przechowuje liczbę rzeczywistą
	}
	public struct dane_robotnik
	{
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public int grupa;//przechowuje liczbę naturalną
		public int nr_oddziału;//przechowuje liczbę naturalną
		public int stan_życia;//przechowuje liczbę naturalną
		public int ilość;//przechowuje liczbę naturalną
	}
	public struct dane_chat
	{
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public float rotacja_x;//przechowuje liczbę rzeczywistą
		public float rotacja_y;//przechowuje liczbę rzeczywistą
		public float rotacja_z;//przechowuje liczbę rzeczywistą
		public float rotacja_w;//przechowuje liczbę rzeczywistą
		public int grupa;//przechowuje liczbę naturalną
		public int nr_oddziału;//przechowuje liczbę naturalną
		public int stan_życia;//przechowuje liczbę naturalną
		public List<string>kolejka;//przechowuje listę ciągów znaków
		public float czas;//przechowuje liczbę rzeczywistą
	}
	public struct dane_drzew
	{
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą
		public int ilość;//przechowuje liczbę naturalną
	}
	public struct dane_GameMaster
	{
		public int ilość;//przechowuje liczbę naturalną
	}
	public struct dane_zadań
	{
		public string tag;//przechowuje ciąg znaków
		public float położenie_x;//przechowuje liczbę rzeczywistą
		public float położenie_y;//przechowuje liczbę rzeczywistą
		public float położenie_z;//przechowuje liczbę rzeczywistą

	}

     
}

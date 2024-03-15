using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DrawWindow : MonoBehaviour
{
    Dictionary<int, File> files = new Dictionary<int, File>();

    public List<Sprite> sprites = new List<Sprite>();

    public GameObject windowPreFab;

    public Canvas canvas;

    void Start()
    {
        createFiles();
    }

    void createFiles() 
    {
        List<File> children = new List<File>();
        File fileExplorer = new File(0,"Folder","File Explorer");
        if (fileExplorer != null)
        {
            File Documents = new File(1, "Folder", "Documents");
            if (Documents != null) 
            {
                File Personal = new File(6, "Folder", "Personal");
                if (Personal != null) 
                {
                    File AREA51 = new File(11, "Folder", "AREA-51 DO-NOT_READ");
                    if (AREA51 != null) 
                    {
                        File Txt3 = new File(14, "Txt", "3");
                        File Txt4 = new File(15, "Txt", "4");
                        File Txt5 = new File(16, "Txt", "5");
                        File Txt6 = new File(17, "Txt", "6");
                        children.Clear();
                        children.Add(Txt3);
                        children.Add(Txt4);
                        children.Add(Txt5);
                        children.Add(Txt6);
                        files.Add(11, AREA51);
                        files[11].addChildren(children);
                    }
                    File Passwords = new File(12, "Folder", "Passwords");
                    if (Passwords != null)
                    {
                        File Txt7 = new File(18, "Txt", "7");
                        File Txt8 = new File(19, "Txt", "8");
                        File Txt9 = new File(20, "Txt", "9");
                        children.Clear();
                        children.Add(Txt7);
                        children.Add(Txt8);
                        children.Add(Txt9);
                        files.Add(12, Passwords);
                        files[12].addChildren(children);
                    }
                    File Taxes = new File(13, "Folder", "Taxes");
                    if (Taxes != null) 
                    {
                        children.Clear();
                        files.Add(13, Taxes);
                        files[13].addChildren(children);
                    }

                    children.Clear();
                    children.Add(AREA51);
                    children.Add(Passwords);
                    children.Add(Taxes);
                    files.Add(6, Personal);
                    files[6].addChildren(children);
                }
                File ToPrint = new File(7, "Folder", "To Print");
                if (ToPrint != null) 
                {
                    File Txt10 = new File(21, "Txt", "10");
                    File Txt11 = new File(22, "Txt", "11");
                    File Txt12 = new File(23, "Txt", "12");
                    children.Clear();
                    children.Add(Txt10);
                    children.Add(Txt11);
                    children.Add(Txt12);
                    files.Add(7, ToPrint);
                    files[7].addChildren(children);
                }
                File Work = new File(8, "Folder", "Work");
                if (Work != null) 
                {
                    File date1 = new File(24, "Folder", "13-03-1998");
                    if (date1 != null)
                    {
                        File Txt13 = new File(26, "Txt", "13");
                        File Txt14 = new File(27, "Txt", "14");
                        File Txt15 = new File(28, "Txt", "15");
                        File Txt16 = new File(29, "Txt", "16");
                        File Txt17 = new File(30, "Txt", "17");
                        children.Clear();
                        children.Add(Txt13);
                        children.Add(Txt14);
                        children.Add(Txt15);
                        children.Add(Txt16);
                        children.Add(Txt17);
                        files.Add(24, date1);
                        files[24].addChildren(children);
                    }
                    File date2 = new File(25, "Folder", "21-03-1998");
                    if (date1 != null)
                    {
                        File Txt18 = new File(31, "Txt", "18");
                        children.Clear();
                        children.Add(Txt18);
                        files.Add(25, date2);
                        files[25].addChildren(children);
                    }
                    children.Clear();
                    children.Add(date1);
                    children.Add(date2);
                    files.Add(8, Work);
                    files[8].addChildren(children);
                }
                File Txt1 = new File(9, "Txt", "1");
                File Txt2 = new File(10, "Txt", "2");

                children.Clear();
                children.Add(Personal);
                children.Add(ToPrint);
                children.Add(Work);
                children.Add(Txt1);
                children.Add(Txt2);
                files.Add(1, Documents);
                files[1].addChildren(children);
            }
            File Downloads = new File(2, "Folder", "Downloads");
            if (Downloads != null) 
            {
                File Txt19 = new File(32, "Txt", "19");
                File Txt20 = new File(33, "Txt", "20");
                File Txt21 = new File(34, "Txt", "21");

                children.Clear();
                children.Add(Txt19);
                children.Add(Txt20);
                children.Add(Txt21);
                files.Add(2, Downloads);
                files[2].addChildren(children);
            }
            File Music = new File(3, "Folder", "Music");
            if (Music != null)
            {
                File Jazz = new File(35, "Folder", "Jazz");
                if (Jazz != null)
                {
                    File Smooth = new File(38, "Folder", "Smooth");
                    if (Smooth != null)
                    {
                        File Txt22 = new File(40, "Txt", "22");
                        File Txt23 = new File(41, "Txt", "23");

                        children.Clear();
                        children.Add(Txt22);
                        children.Add(Txt23);
                        files.Add(38, Smooth);
                        files[38].addChildren(children);
                    }
                    File Swing = new File(39, "Folder", "Swing");
                    if (Swing != null)
                    {
                        File Txt24 = new File(42, "Txt", "24");
                        File Txt25 = new File(43, "Txt", "25");
                        File Txt26 = new File(44, "Txt", "26");
                        File Txt27 = new File(45, "Txt", "27");

                        children.Clear();
                        children.Add(Txt24);
                        children.Add(Txt25);
                        children.Add(Txt26);
                        children.Add(Txt27);
                        files.Add(39, Swing);
                        files[39].addChildren(children);
                    }

                    children.Clear();
                    children.Add(Smooth);
                    children.Add(Swing);
                    files.Add(35, Jazz);
                    files[35].addChildren(children);
                }
                File pop = new File(36, "Folder", "Pop");
                if (pop != null)
                {
                    File jpop = new File(46, "Folder", "J-Pop");
                    if (jpop != null)
                    {
                        File Txt28 = new File(49, "Txt", "28");

                        children.Clear();
                        children.Add(Txt28);
                        files.Add(46, jpop);
                        files[46].addChildren(children);
                    }
                    File kpop = new File(47, "Folder", "K-Pop");
                    if (kpop != null)
                    {
                        File Txt29 = new File(50, "Txt", "29");
                        File Txt30 = new File(51, "Txt", "30");
                        File Txt31 = new File(52, "Txt", "31");
                        File Txt32 = new File(53, "Txt", "32");
                        File Txt33 = new File(54, "Txt", "33");
                        File Txt34 = new File(55, "Txt", "34");
                        File Txt35 = new File(56, "Txt", "35");
                        File Txt36 = new File(57, "Txt", "36");

                        children.Clear();
                        children.Add(Txt29);
                        children.Add(Txt30);
                        children.Add(Txt31);
                        children.Add(Txt32);
                        children.Add(Txt33);
                        children.Add(Txt34);
                        children.Add(Txt35);
                        children.Add(Txt36);
                        files.Add(47, kpop);
                        files[47].addChildren(children);
                    }
                    File popPunk = new File(48, "Folder", "Pop-Punk");
                    if (popPunk != null)
                    {
                        File Txt37 = new File(58, "Txt", "37");
                        File Txt38 = new File(59, "Txt", "38");

                        children.Clear();
                        children.Add(Txt37);
                        children.Add(Txt38);
                        files.Add(48, popPunk);
                        files[48].addChildren(children);
                    }

                    children.Clear();
                    children.Add(jpop);
                    children.Add(kpop);
                    children.Add(popPunk);
                    files.Add(36, pop);
                    files[36].addChildren(children);
                }
                File rock = new File(37, "Folder", "Rock");
                if (rock != null) 
                {
                    File indie = new File(60, "Folder", "indie");
                    if (indie != null) 
                    { 
                        File Txt39 = new File(63, "Txt", "39");

                        children.Clear();
                        children.Add(Txt39);
                        files.Add(60, indie);
                        files[60].addChildren(children);
                    }
                    File metal = new File(61, "Folder", "metal");
                    if (metal != null)
                    {
                        File Txt40 = new File(64, "Txt", "40");
                        File Txt41 = new File(65, "Txt", "41");
                        File Txt42 = new File(66, "Txt", "42");

                        children.Clear();
                        children.Add(Txt40);
                        children.Add(Txt41);
                        children.Add(Txt42);
                        files.Add(61, metal);
                        files[61].addChildren(children);
                    }
                    File poprock = new File(62, "Folder", "pop-rock");
                    if (poprock != null)
                    {
                        File Txt43 = new File(67, "Txt", "43");
                        File Txt44 = new File(68, "Txt", "44");
                        File Txt45 = new File(69, "Txt", "45");
                        File Txt46 = new File(70, "Txt", "46");
                        File Txt47 = new File(71, "Txt", "47");
                        File Txt48 = new File(72, "Txt", "48");

                        children.Clear();
                        children.Add(Txt43);
                        children.Add(Txt44);
                        children.Add(Txt45);
                        children.Add(Txt46);
                        children.Add(Txt47);
                        children.Add(Txt48);
                        files.Add(62, poprock);
                        files[62].addChildren(children);
                    }

                    children.Clear();
                    children.Add(indie);
                    children.Add(metal);
                    children.Add(poprock);
                    files.Add(37, rock);
                    files[37].addChildren(children);
                }
                children.Clear();
                children.Add(Jazz);
                children.Add(pop);
                children.Add(rock);
                files.Add(3, Music);
                files[3].addChildren(children);
            }
            File Pictures = new File(4, "Folder", "Pictures");
            if (Pictures != null) 
            {
                File Family = new File(73, "Folder", "Family");
                if (Family != null)
                {
                    File Children1 = new File(75, "Folder", "Children");
                    if (Children1 != null) 
                    { 
                        File Txt51 = new File(82, "Txt", "51");
                        File Txt52 = new File(83, "Txt", "52");
                        File Txt53 = new File(84, "Txt", "53");
                        File Txt54 = new File(85, "Txt", "54");
                        File Txt55 = new File(86, "Txt", "55");
                        File Txt56 = new File(87, "Txt", "56");

                        children.Clear();
                        children.Add(Txt51);
                        children.Add(Txt52);
                        children.Add(Txt53);
                        children.Add(Txt54);
                        children.Add(Txt55);
                        children.Add(Txt56);
                        files.Add(75, Children1);
                        files[75].addChildren(children);
                    }
                    File Husband = new File(76, "Folder", "Husband");
                    if (Husband != null) 
                    { 
                        File Txt57 = new File(88, "Txt", "57");
                        File Txt58 = new File(89, "Txt", "58");
                        File Txt59 = new File(90, "Txt", "59");
                        File Txt60 = new File(91, "Txt", "60");
                        File Txt61 = new File(92, "Txt", "61");
                        File Txt62 = new File(93, "Txt", "62");

                        children.Clear();
                        children.Add(Txt57);
                        children.Add(Txt58);
                        children.Add(Txt59);
                        children.Add(Txt60);
                        children.Add(Txt61);
                        children.Add(Txt62);
                        files.Add(76, Husband);
                        files[76].addChildren(children);
                    }
                    File Parents = new File(77, "Folder", "Parents");
                    if (Parents != null) 
                    { 
                        File Txt63 = new File(94, "Txt", "63");
                        File Txt64 = new File(95, "Txt", "64");

                        children.Clear();
                        children.Add(Txt63);
                        children.Add(Txt64);
                        files.Add(77, Parents);
                        files[77].addChildren(children);
                    }
                    File Pets = new File(78, "Folder", "Pets");
                    if (Pets != null) 
                    {
                        File cats = new File(96, "Folder", "Cats");
                        if (cats != null)
                        {
                            File Txt65 = new File(98, "Txt", "65");
                            File Txt66 = new File(99, "Txt", "66");
                            File Txt67 = new File(100, "Txt", "67");
                            File Txt68 = new File(101, "Txt", "68");
                            File Txt69 = new File(102, "Txt", "69");
                            File Txt70 = new File(103, "Txt", "70");

                            children.Clear();
                            children.Add(Txt65);
                            children.Add(Txt66);
                            children.Add(Txt67);
                            children.Add(Txt68);
                            children.Add(Txt69);
                            children.Add(Txt70);
                            files.Add(96, cats);
                            files[96].addChildren(children);
                        }
                        File dogs = new File(97, "Folder", "Dogs");
                        if (dogs != null)
                        {
                            File Txt71 = new File(104, "Txt", "71");
                            File Txt72 = new File(105, "Txt", "72");
                            File Txt73 = new File(106, "Txt", "73");

                            children.Clear();
                            children.Add(Txt71);
                            children.Add(Txt72);
                            children.Add(Txt73);
                            files.Add(97, dogs);
                            files[97].addChildren(children);
                        }

                        children.Clear();
                        children.Add(cats);
                        children.Add(dogs);
                        files.Add(78, Pets);
                        files[78].addChildren(children);
                    }
                    File Wife = new File(79, "Folder", "Wife");
                    if (Wife != null) 
                    {
                        File Txt74 = new File(107, "Txt", "74");
                        File Txt75 = new File(108, "Txt", "75");
                        File Txt76 = new File(109, "Txt", "76");
                        File Txt77 = new File(110, "Txt", "77");


                        children.Clear();
                        children.Add(Txt74);
                        children.Add(Txt75);
                        children.Add(Txt76);
                        children.Add(Txt77);
                        files.Add(79, Wife);
                        files[79].addChildren(children);
                    }
                    File Txt49 = new File(80, "Txt", "49");
                    File Txt50 = new File(81, "Txt", "50");

                    children.Clear();
                    children.Add(Children1);
                    children.Add(Husband);
                    children.Add(Parents);
                    children.Add(Pets);
                    children.Add(Wife);
                    children.Add(Txt49);
                    children.Add(Txt50);
                    files.Add(73, Family);
                    files[73].addChildren(children);
                }
                File Work = new File(74, "Folder", "Work");
                if (Work != null) 
                {
                    File BBQ = new File(111, "Folder", "BBQ");
                    if (BBQ != null) 
                    { 
                        File Txt79 = new File(115, "Txt", "79");
                        File Txt80 = new File(116, "Txt", "80");
                        File Txt81 = new File(117, "Txt", "81");

                        children.Clear();
                        children.Add(Txt79);
                        children.Add(Txt80);
                        children.Add(Txt81);
                        files.Add(111, BBQ);
                        files[111].addChildren(children);
                    }
                    File Social = new File(112, "Folder", "Social");
                    if (Social != null) 
                    { 
                        File Txt82 = new File(118, "Txt", "82");
                        File Txt83 = new File(119, "Txt", "83");
                        File Txt84 = new File(120, "Txt", "84");

                        children.Clear();
                        children.Add(Txt82);
                        children.Add(Txt83);
                        children.Add(Txt84);
                        files.Add(112, Social);
                        files[112].addChildren(children);
                    }
                    File SpeardSheets = new File(113, "Folder", "SpeardSheets");
                    if (SpeardSheets != null) 
                    { 
                        File Txt85 = new File(121, "Txt", "85");
                        File Txt86 = new File(122, "Txt", "86");
                        File Txt87 = new File(123, "Txt", "87");
                        File Txt88 = new File(124, "Txt", "88");
                        File Txt89 = new File(125, "Txt", "89");

                        children.Clear();
                        children.Add(Txt85);
                        children.Add(Txt86);
                        children.Add(Txt87);
                        children.Add(Txt88);
                        children.Add(Txt89);
                        files.Add(113, SpeardSheets);
                        files[113].addChildren(children);
                    }
                    File Txt78 = new File(114, "Txt", "78");

                    children.Clear();
                    children.Add(BBQ);
                    children.Add(Social);
                    children.Add(SpeardSheets);
                    children.Add(Txt78);
                    files.Add(74, Work);
                    files[74].addChildren(children);
                }
                children.Clear();
                children.Add(Family);
                children.Add(Work);
                files.Add(4, Pictures);
                files[4].addChildren(children);
            }
            File Videos = new File(5, "Folder", "Videos");
            if (Videos != null) 
            {
                File Home = new File(123, "Folder", "Home");
                if (Home != null) 
                {
                    File Txt90 = new File(126, "Txt", "90");
                    File Txt91 = new File(127, "Txt", "91");
                    File Txt92 = new File(128, "Txt", "92");
                    children.Clear();
                    children.Add(Txt90);
                    children.Add(Txt91);
                    children.Add(Txt92);
                    files.Add(123, Home);
                    files[123].addChildren(children);
                }
                File Movies = new File(124, "Folder", "Videos");
                if (Movies != null) 
                { 
                    File Txt93 = new File(129, "Txt", "93");
                    File Txt94 = new File(130, "Txt", "94");
                    File Txt95 = new File(131, "Txt", "95");
                    children.Clear();
                    children.Add(Txt93);
                    children.Add(Txt93);
                    children.Add(Txt93);
                    files.Add(124, Movies);
                    files[124].addChildren(children);
                }
                File Tv = new File(125, "Folder", "Videos");
                if (Tv != null) 
                { 
                    File Txt96 = new File(132, "Txt", "96");
                    File Txt97 = new File(133, "Txt", "97");
                    File Txt98 = new File(134, "Txt", "98");
                    File Txt99 = new File(135, "Txt", "99");
                    File Txt100 = new File(136, "Txt", "100");
                    children.Clear();
                    children.Add(Txt96);
                    children.Add(Txt97);
                    children.Add(Txt98);
                    children.Add(Txt99);
                    children.Add(Txt100);
                    files.Add(125, Tv);
                    files[125].addChildren(children);
                }
                children.Clear();
                children.Add(Home);
                children.Add(Movies);
                children.Add(Tv);
                files.Add(5, Videos);
                files[5].addChildren(children);
            }
            children.Clear();
            children.Add(Documents);
            children.Add(Downloads);
            children.Add(Music);
            children.Add(Pictures);
            children.Add(Videos);
            files.Add(0,fileExplorer);
            files[0].addChildren(children);
        }
    }

    public void createWindow(int ID) 
    {
        GameObject clone = Instantiate(windowPreFab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        clone.GetComponent<Window>().thisFile = files[ID];
        clone.transform.localScale = new Vector3(1f, 1f, 1f);
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, 0);
        clone.transform.localPosition = new Vector3(clone.transform.localPosition.x, clone.transform.localPosition.y, 0);
        clone.GetComponent<Window>().canvas = canvas;
        clone.GetComponent<Window>().DrawFiles();
    }

    public void startWindow() 
    {
        GameObject clone = Instantiate(windowPreFab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        clone.GetComponent<Window>().thisFile = files[0];
        clone.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

public class File
{
    public int ID;
    public string type;
    public string name;
    //File parent;
    public List<File> children;

    bool isDeleted = false;
    bool isCurrupted = false;
    bool isCurrupting = false;
    float curruptionPercent = 0;

    public File(int _ID, string _type, string _name)
    { 
        ID = _ID;
        type = _type;
        name = _name;
        children = new List<File>();
    }

    public void addChildren(List<File> _children) 
    { 
        children.AddRange(_children);
    }
}

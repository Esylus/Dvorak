using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DvorakTrainer;
using DvorakTrainer.Entities;

namespace Dvorak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private KeyRandomizer userKeyListObject;
        private Statistics sessionStatistics;
        private GameTimer sessionTimer;
        private FadeTimer pointFade;
        private Focus sessionFocus;
        private bool disableKeyBoard = true;

        public void btnPractice_Click(object sender, EventArgs e)
        {
            startSession();
        }

        private void startSession() // initiates practice session 
        {
            userKeyListObject = new KeyRandomizer(putUserSelectedKeysIntoList());

            sessionStatistics = new Statistics();

            sessionTimer = new GameTimer();

            statisticDisplaysClear();

            lblDvorak.Hide();
            lblMain.Show();

            disableKeyBoard = false;

            timer1.Start();

            getRandomKeyAndDisplay();
        }

        private List<int> putUserSelectedKeysIntoList() // Return a list of all selected keys 
        {
            List<int> mySelectedKeys = new List<int>();

            List<CheckBox> allCheckBoxNames = new List<CheckBox>()
            {
                cbEsc,cbF1,cbF2,cbF3,cbF4,cbF5,cbF6,cbF7,cbF8,cbF9,cbF10,cbF11,cbF12,cbTilda,cb1,
                cb2,cb3,cb4,cb5,cb6,cb7,cb8,cb9,cb0,cbLSqr,cbRSqr,cbBack,cbLTab,cbQte,cbComma,cbPrd,cbP,
                cbY,cbF,cbG,cbC,cbR,cbL,cbFSlsh,cbEql,cbBSlsh,cbCaps,cbA,cbO,cbE,cbU,cbI,cbD,cbH,cbT,cbN,
                cbS,cbDash,cbEntr,cbLShft,cbColon,cbQ,cbJ,cbK,cbX,cbB,cbM,cbW,cbV,cbZ,cbRShft,cbLCtrl,cbStrt,
                cbLAlt,cbSpace,cbLAlt,cbMenu,cbRCtrl
            };

            Dictionary<int, CheckBox> keyIntDictChecked = new Dictionary<int, CheckBox>();

                {
                    int count = 0;
                    foreach (CheckBox cb in allCheckBoxNames)
                    {
                        keyIntDictChecked.Add(count, cb);
                        count++;
                    }
                }

            List<CheckBox> allCheckBoxNamesIndeterminate = new List<CheckBox>()
            {            
                cbTilda,cb1,cb2,cb3,cb4,cb5,cb6,cb7,cb8,cb9,cb0,cbLSqr,cbRSqr,
                cbQte,cbComma,cbPrd,cbFSlsh,cbEql,cbBSlsh,cbDash,cbColon
             };

            Dictionary<int, CheckBox> keyIntDictIndeterminate = new Dictionary<int, CheckBox>();


                {
                    int count1 = 73;
                    foreach (CheckBox cb in allCheckBoxNamesIndeterminate)
                    {
                        keyIntDictIndeterminate.Add(count1, cb);
                        count1++;
                    }
                }

                foreach (var keyPair in keyIntDictChecked)
                {// add first half of keys  
                    keyIntDictIndeterminate.Add(keyPair.Key, keyPair.Value);
                }

            while (!mySelectedKeys.Any()) // ensures that the list will never be empty
            {

                foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                {
                    if (cb.CheckState == CheckState.Checked)
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in keyIntDictChecked) // REFACTOR ME INTO A METHOD AND CLASS                                                                                    
                        {  // look up in Dictionary and add number to mySelectedKeys
                            if (cb == keyString.Value)
                            {
                                mySelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                    else if (cb.CheckState == CheckState.Indeterminate) // tristate cb is indeterminate
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in keyIntDictIndeterminate) // look up in Dictionary and add number to mySelectedKeys
                        {
                            if (cb == keyString.Value)
                            {
                                mySelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                }              

                if (!mySelectedKeys.Any()) // if no keys selected up to now, select all keys           
                    keysAll();
            }

            if (mySelectedKeys.Count < 2)
            {//since an algorithm prevents keys from repeating, thus if only a single key is selected the below default will select the home row

                MessageBox.Show("Must select minimum two keys as letters are unable to repeat themselves. " +
                                "Now practice your home row or hit Reset to try again!");
                mySelectedKeys.Clear();
                keysClear();
                int[] range = {42, 43, 44, 45, 46, 47, 48, 49, 50, 51};               
                mySelectedKeys.AddRange(range);
                CheckBox[] cbRange = new CheckBox[]{cbA, cbO, cbE, cbU, cbI, cbD, cbH, cbT, cbN, cbS};
                foreach (CheckBox cb in cbRange)
                {
                    cb.Checked = true;
                }
            }
            return mySelectedKeys;
        }

        private void getRandomKeyAndDisplay() //Gets random key from user selected list and displays
        {
            if (sessionFocus != null) // if focus button (cb) has been pushed and object initialized..
            {
                if (sessionFocus.FocusModeEnabled) // if first round of focus learning has gone by there will be a focusList created
                {
                    userKeyListObject.extractUserRandomKeyToMember(sessionFocus
                        .FocusList); // Use this list after 1st round data collection
                }
                else // if focus button is pushed but it is the first focus learning round
                {
                    userKeyListObject.extractUserRandomKeyToMember(userKeyListObject
                        .UserSelectedKeyList); // use default list
                }
            }
            else // if the focus button is not pushed
            {
                userKeyListObject.extractUserRandomKeyToMember(userKeyListObject.UserSelectedKeyList); // Default list
            }

            List<String> allCheckBoxStrings = new List<String>()    // change display characters here
            {
                "Esc","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12","`","1","2","3","4",
                 "5","6","7","8","9","0","[","]","Back","Tab","'",",",".","p","y","f","g","c","r","l","/",
                 "=","\\","Caps","a","o","e","u","i","d","h","t","n","s","-","Enter","Shift",";","q","j","k",
                 "x","b","m","w","v","z","Shift","Ctrl","Start","Alt","Space","Alt","Menu","Ctrl","~","!","@",
                 "#","$","%","^","&&","*","(",")","{","}","\"","<",">","?","+","| pipe","_",":",              
            };

            Dictionary<int, string> keyStringDict = new Dictionary<int, string>();
           
            int count = 0;
            foreach (String str in allCheckBoxStrings)
            {
                keyStringDict.Add(count, str);
                count++;
            }

            foreach (KeyValuePair<int, string> keyString in keyStringDict)
            {
                if (keyString.Key == userKeyListObject.CurrentRandomKey)
                {
                    lblMain.Text = keyString.Value;
                }
            }
        }

        private void
            Form1_KeyUp(object sender, KeyEventArgs e) //TRACK USER INTERACTION - if user input matches selected key, tally score and get new key 
        {
            if (disableKeyBoard)
            {
                return;
            }

          

            List<Keys> allCheckBoxKeys = new List<Keys>()
            {
                Keys.Escape,Keys.F1,Keys.F2,Keys.F3,Keys.F4,Keys.F5,Keys.F6,Keys.F7,Keys.F8,Keys.F9,Keys.F10,Keys.F11,Keys.F12,Keys.Oemtilde,
                 Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9,Keys.D0,Keys.OemOpenBrackets,Keys.OemCloseBrackets,
                 Keys.Back,Keys.Tab,Keys.OemQuotes,Keys.Oemcomma,Keys.OemPeriod,Keys.P,Keys.Y,Keys.F,Keys.G,Keys.C,Keys.R,Keys.L,Keys.OemQuestion,
                 Keys.Oemplus,Keys.OemPipe,Keys.CapsLock,Keys.A,Keys.O,Keys.E,Keys.U,Keys.I,Keys.D,Keys.H,Keys.T,Keys.N,Keys.S,Keys.OemMinus,
                 Keys.Enter,Keys.ShiftKey,Keys.OemSemicolon,Keys.Q,Keys.J,Keys.K,Keys.X,Keys.B,Keys.M,Keys.W,Keys.V,Keys.Z,Keys.ShiftKey,Keys.ControlKey,
                 Keys.Menu,Keys.Alt,Keys.Space,Keys.Alt,Keys.Menu,Keys.ControlKey
            };

            Dictionary<int, Keys> keyCodesInts = new Dictionary<int, Keys>();

            {
                int count = 0;
                foreach (Keys key in allCheckBoxKeys)
                {
                    keyCodesInts.Add(count, key);
                    count++;
                }
            }

            List<Keys> allCheckBoxShiftKeys = new List<Keys>()   
            {
                Keys.Oemtilde,Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9,Keys.D0,Keys.OemOpenBrackets,Keys.OemCloseBrackets,
                Keys.OemQuotes,Keys.Oemcomma,Keys.OemPeriod,Keys.OemQuestion,Keys.Oemplus,Keys.OemPipe,Keys.OemMinus,Keys.OemSemicolon
            };

            Dictionary<int, Keys> keyShiftCodesInts = new Dictionary<int, Keys>();

            {
                int shiftCount = 73;
                foreach (Keys key in allCheckBoxShiftKeys)
                {
                    keyShiftCodesInts.Add(shiftCount, key);
                    shiftCount++;
                }
            }

            if (!e.Shift) // for key presses without shift 
            {

                foreach (KeyValuePair<int, Keys> keyCode in keyCodesInts)
                {
                    if ((e.KeyCode == keyCode.Value) && (userKeyListObject.CurrentRandomKey == keyCode.Key))
                    {
                        playAgain();
                    }

                    else if (e.KeyCode == keyCode.Value)
                    {
                        if ((keyCode.Value != Keys.ShiftKey) && (keyCode.Value != Keys.Space))
                        {
                            trackTotal();
                        }
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<int, Keys> keyCode in keyShiftCodesInts)
                {
                    if ((e.KeyCode == keyCode.Value && e.Shift) && (userKeyListObject.CurrentRandomKey == keyCode.Key))
                    {
                        playAgain();
                    }

                    else if (e.KeyCode == keyCode.Value && e.Shift)
                    {
                        trackTotal();
                    }
                }
            }
        }         

            private void cbFocus_CheckedChanged(object sender, EventArgs e) // activates focus mode
            {
                if (cbFocus.Checked) // if focus cb checked, initialize focus object
                {
                    sessionFocus = new Focus();
                }
                else
                {
                    sessionFocus.FocusModeEnabled = false; // if user takes focus mode off, disable
                }
            }

            private void playAgain() // add point to correct / +5 to points, get next key
            {
                if (cbFocus.Checked) // if in focus mode, collect result data
                {
                    sessionFocus.recordKeyPressResults(userKeyListObject.CurrentRandomKey, 1);
                }

                sessionStatistics.Correct++;
                sessionStatistics.Total++;
                sessionStatistics.TotalPoints += 5;

                pointFade = new FadeTimer(0, 255, 0); // create fade object
                pointFade.PositiveOrNegativePoints = true; // assign positive bool
                FadeTimer.Start(); //start timer which will display points then fade

                getScoreAndDisplayStatistics();
                getRandomKeyAndDisplay();
            }

            private void trackTotal() // add point to total / -3 to points when user answer incorrect, refresh statistics display
            {
                if (cbFocus.Checked)
                {
                    sessionFocus.recordKeyPressResults(userKeyListObject.CurrentRandomKey, 0);
                }

                sessionStatistics.Total++;

                sessionStatistics.TotalPoints -= 3;

                pointFade = new FadeTimer(255, 0, 0);
                pointFade.PositiveOrNegativePoints = false;
                FadeTimer.Start();
                getScoreAndDisplayStatistics();
            }

            private void getScoreAndDisplayStatistics()
            {

                decimal correct = sessionStatistics.Correct;
                decimal total = sessionStatistics.Total;
                decimal accuracy = sessionStatistics.Accuracy;
                int totalPoints = sessionStatistics.TotalPoints;

                lblTotalDisplay.Text = totalPoints.ToString();

                if (total != 0) // only calculate score after minimum 1 key is pressed
                {
                    accuracy = sessionStatistics.calculateAccuracy(correct, total);
                    lblAccuracyDisplay.Text = accuracy.ToString("P");
                }

            }

            private void btnReset_Click(object sender, EventArgs e) // reset game to initialized state
            {
                statisticDisplaysClear();
                timer1.Stop();
                keysClear();
                disableKeyBoard = true;
                lblDvorak.Show();
                cbFocus.Checked = false;
            }

       

            private void statisticDisplaysClear()
            {
                lblPointsDisplay.Text = "";
                lblAccuracyDisplay.Text = "";
                lblTotalDisplay.Text = "";
                lblTimerDisplay.Text = "";
            }

            private void keysClear() // clear all checkButtons
            {
                foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                {
                    if (cb.Controls.GetType() == cbF1.GetType())
                    {
                        cb.Checked = false;
                    }
                    else
                    {
                        cb.CheckState = CheckState.Unchecked;
                    }
                }
            }

            private void keysAll() // check all checkbuttons for edge case where user selects nothing
            {
                foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                {
                    if (cb.Controls.GetType() == cbF1.GetType())
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.CheckState = CheckState.Indeterminate;
                    }
                }
                cbLAlt.Checked = false;
                cbRAlt.Checked = false;
                cbStrt.Checked = false;
                cbSpace.Checked = false;
                cbPW.Checked = false;
                cbMenu.Checked = false;
                cbCaps.Checked = false; 

            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                sessionTimer.TimerCount--;
                lblTimerDisplay.Text = (sessionTimer.TimerCount / 10).ToString();

                if (sessionTimer.TimerCount == 0) // when round is over
                {
                    timer1.Stop();
                    lblMain.Text = "Time";
                    disableKeyBoard = true;

                    if (cbFocus.Checked
                    ) // focus-mode, after first round of data collected, create next rounds list and enable focus mode 
                    {
                        sessionFocus.createFocusList();
                        sessionFocus.FocusModeEnabled = true;
                    }
                }
            }

            private void FadeTimer_Tick(object sender, EventArgs e) // allows points added or subtracted to fade away
            {
                pointFade.FadeTimerCount--;
                int endColor = 105;
                int fadeRate = 5;

                if (pointFade.PositiveOrNegativePoints)
                {
                    // if positive points apply green color + fade
                    lblPointsDisplay.ForeColor = Color.FromArgb(pointFade.R, pointFade.G, pointFade.B);
                    lblPointsDisplay.Text = "+5";

                    if (pointFade.R < endColor) pointFade.R += fadeRate;
                    if (pointFade.G > endColor) pointFade.G -= fadeRate;
                    if (pointFade.B < endColor) pointFade.B += fadeRate;
                }
                else
                {
                    // if negative points apply red color + fade
                    lblPointsDisplay.ForeColor = Color.FromArgb(pointFade.R, pointFade.G, pointFade.B);
                    ;
                    lblPointsDisplay.Text = "-3";

                    if (pointFade.R > endColor) pointFade.R -= fadeRate;
                    if (pointFade.G < endColor) pointFade.G += fadeRate;
                    if (pointFade.B < endColor) pointFade.B += fadeRate;
                }

                if (pointFade.FadeTimerCount == 0)
                {
                    FadeTimer.Stop();
                }
            }

            private void
            cbFingerings_CheckedChanged(object sender, EventArgs e) // toggle viewing correct key fingerings
            {
                Fingerings one = new Fingerings(155, 255, 131, 62); // thumb
                Fingerings two = new Fingerings(155, 132, 138, 224); // pointer
                Fingerings three = new Fingerings(155, 149, 73, 203); // middle
                Fingerings four = new Fingerings(155, 160, 192, 76); // ring
                Fingerings five = new Fingerings(155, 0, 153, 217); // pinky

                CheckBox[] pinky = new CheckBox[]
                {
                    cbEsc, cbF11, cbF12, cbTilda, cb1, cbRSqr, cbBack, cbLTab, cbQte,
                    cbBSlsh, cbEql, cbFSlsh, cbCaps, cbA, cbS, cbDash, cbEntr, cbLShft, cbColon, cbZ, cbRShft, cbLCtrl,
                    cbStrt, cbRCtrl
                };
                CheckBox[] ring = new CheckBox[]
                {
                    cbF1, cbF2, cbF3, cbF9, cbF10, cb2, cb3, cb0, cbLSqr, cbComma, cbR, cbL, cbO, cbN, cbQ, cbV, cbMenu
                };
                CheckBox[] middle = new CheckBox[] {cbF4, cbF8, cb4, cb9, cbPrd, cbC, cbE, cbT, cbJ, cbW};
                CheckBox[] pointer = new CheckBox[]
                    {cbF5, cbF6, cbF7, cb5, cb6, cb7, cb8, cbP, cbY, cbF, cbG, cbU, cbI, cbD, cbH, cbK, cbX, cbB, cbM};
                CheckBox[] thumb = new CheckBox[] {cbLAlt, cbSpace, cbRAlt};

                if (cbFingerings.Checked)
                {
                    foreach (CheckBox cbPinky in pinky)
                    {
                        cbPinky.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                    }

                    foreach (CheckBox cbRing in ring)
                    {
                        cbRing.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                    }

                    foreach (CheckBox cbMiddle in middle)
                    {
                        cbMiddle.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                    }

                    foreach (CheckBox cbPointer in pointer)
                    {
                        cbPointer.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                    }

                    foreach (CheckBox cbThumb in thumb)
                    {
                        cbThumb.BackColor = Color.FromArgb(one.O, one.R, one.G, one.B);
                    }
                }
                else
                {
                    foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                    {
                        cb.BackColor = default(Color);
                        cb.UseVisualStyleBackColor = true;
                    }
                }
            }            
    }
}

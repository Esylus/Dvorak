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

            Dictionary<int, CheckBox> keyIntDictChecked = new Dictionary<int, CheckBox>()
            {
                {0, cbEsc},
                {1, cbF1},
                {2, cbF2},
                {3, cbF3},
                {4, cbF4},
                {5, cbF5},
                {6, cbF6},
                {7, cbF7},
                {8, cbF8},
                {9, cbF9},
                {10, cbF10},
                {11, cbF11},
                {12, cbF12},
                {13, cbTilda},
                {14, cb1},
                {15, cb2},
                {16, cb3},
                {17, cb4},
                {18, cb5},
                {19, cb6},
                {20, cb7},
                {21, cb8},
                {22, cb9},
                {23, cb0},
                {24, cbLSqr},
                {25, cbRSqr},
                {26, cbBack},
                {27, cbLTab},
                {28, cbQte},
                {29, cbComma},
                {30, cbPrd},
                {31, cbP},
                {32, cbY},
                {33, cbF},
                {34, cbG},
                {35, cbC},
                {36, cbR},
                {37, cbL},
                {38, cbFSlsh},
                {39, cbEql},
                {40, cbBSlsh},
                {41, cbCaps},
                {42, cbA},
                {43, cbO},
                {44, cbE},
                {45, cbU},
                {46, cbI},
                {47, cbD},
                {48, cbH},
                {49, cbT},
                {50, cbN},
                {51, cbS},
                {52, cbDash},
                {53, cbEntr},
                {54, cbLShft},
                {55, cbColon},
                {56, cbQ},
                {57, cbJ},
                {58, cbK},
                {59, cbX},
                {60, cbB},
                {61, cbM},
                {62, cbW},
                {63, cbV},
                {64, cbZ},
                {65, cbRShft},
                {66, cbLCtrl},
                {67, cbStrt},
                {68, cbLAlt},
                {69, cbSpace},
                {70, cbLAlt},
                {71, cbMenu},
                {72, cbRCtrl},
                
            }; // PUT ME INTO A CLASS

            Dictionary<int, CheckBox> keyIntDictIndeterminate = new Dictionary<int, CheckBox>()
            {
                {73, cbTilda},
                {74, cb1},
                {75, cb2},
                {76, cb3},
                {77, cb4}, 
                {78, cb5},
                {79, cb6},
                {80, cb7},
                {81, cb8},
                {82, cb9},
                {83, cb0},
                {84, cbLSqr},
                {85, cbRSqr},
                {86, cbQte},
                {87, cbComma},
                {88, cbPrd},
                {89, cbFSlsh},
                {90, cbEql},
                {91, cbBSlsh},
                {92, cbDash},
                {93, cbColon}
            }; // PUT ME INTO A CLASS

            foreach (var keyPair in keyIntDictChecked)
            {// add keyIntDictChecked dictionary 
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

                MessageBox.Show("Must select minimum two keys as letters are unable to repeat themselves. Now practice your home row or hit Reset to try again!");
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
                if (sessionFocus.FocusModeEnabled
                ) // if first round of focus learning has gone by there will be a focusList created
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

            Dictionary<int, string> keyStringDict = new Dictionary<int, string>()
            {
                {0, "Esc"},
                {1, "F1"},
                {2, "F2"},
                {3, "F3"},
                {4, "F4"},
                {5, "F5"},
                {6, "F6"},
                {7, "F7"},
                {8, "F8"},
                {9, "F9"},
                {10, "F10"},
                {11, "F11"},
                {12, "F12"},
                {13, "`"},
                {14, "1"},
                {15, "2"},
                {16, "3"},
                {17, "4"},
                {18, "5"},
                {19, "6"},
                {20, "7"},
                {21, "8"},
                {22, "9"},
                {23, "0"},
                {24, "["},
                {25, "]"},
                {26, "Back"},
                {27, "Tab"},
                {28, "'"},
                {29, ","},
                {30, "."},
                {31, "p"},
                {32, "y"},
                {33, "f"},
                {34, "g"},
                {35, "c"},
                {36, "r"},
                {37, "l"},
                {38, "/"},
                {39, "="},
                {40, "\\"},
                {41, "Caps"},
                {42, "a"},
                {43, "o"},
                {44, "e"},
                {45, "u"},
                {46, "i"},
                {47, "d"},
                {48, "h"},
                {49, "t"},
                {50, "n"},
                {51, "s"},
                {52, "-"},
                {53, "Enter"},
                {54, "Shift"},
                {55, ";"},
                {56, "q"},
                {57, "j"},
                {58, "k"},
                {59, "x"},
                {60, "b"},
                {61, "m"},
                {62, "w"},
                {63, "v"},
                {64, "z"},
                {65, "Shift"},
                {66, "Ctrl"},
                {67, "Start"},
                {68, "Alt"},
                {69, "Space"},
                {70, "Alt"},
                {71, "Menu"},
                {72, "Ctrl"},
                {73, "~"},
                {74, "!"},
                {75, "@"},
                {76, "#"},
                {77, "$"},
                {78, "%"},
                {79, "^"},
                {80, "&&"},
                {81, "*"},
                {82, "("},
                {83, ")"},
                {84, "{"},
                {85, "}"},
                {86, "\""},
                {87, "<"},
                {88, ">"},
                {89, "?"},
                {90, "+"},
                {91, "| pipe"},
                {92, "_"},
                {93, ":"},
            };

            foreach (KeyValuePair<int, string> keyString in keyStringDict)
            {
                if (keyString.Key == userKeyListObject.CurrentRandomKey)
                {
                    lblMain.Text = keyString.Value;
                }
            }
        }

        private void
            Form1_KeyUp(object sender,
                KeyEventArgs e) //TRACK USER INTERACTION - if user input matches selected key, tally score and get new key 
        {
            if (disableKeyBoard)
            {
                return;
            }

            // make dictionary of keycodes  

            Dictionary<int, Keys> keyCodesInts = new Dictionary<int, Keys>()
            {
                {0, Keys.Escape},
                {1, Keys.F1},
                {2, Keys.F2},
                {3, Keys.F3},
                {4, Keys.F4},
                {5, Keys.F5},
                {6, Keys.F6},
                {7, Keys.F7},
                {8, Keys.F8},
                {9, Keys.F9},
                {10, Keys.F10},
                {11, Keys.F11},
                {12, Keys.F12},
                {13, Keys.Oemtilde},
                {14, Keys.D1},
                {15, Keys.D2},
                {16, Keys.D3},
                {17, Keys.D4},
                {18, Keys.D5},
                {19, Keys.D6},
                {20, Keys.D7},
                {21, Keys.D8},
                {22, Keys.D9},
                {23, Keys.D0},
                {24, Keys.OemOpenBrackets},
                {25, Keys.OemCloseBrackets},
                {26, Keys.Back},
                {27, Keys.Tab},
                {28, Keys.OemQuotes},
                {29, Keys.Oemcomma},
                {30, Keys.OemPeriod},
                {31, Keys.P},
                {32, Keys.Y},
                {33, Keys.F},
                {34, Keys.G},
                {35, Keys.C},
                {36, Keys.R},
                {37, Keys.L},
                {38, Keys.OemQuestion},
                {39, Keys.Oemplus},
                {40, Keys.OemPipe},
                {41, Keys.CapsLock},
                {42, Keys.A},
                {43, Keys.O},
                {44, Keys.E},
                {45, Keys.U},
                {46, Keys.I},
                {47, Keys.D},
                {48, Keys.H},
                {49, Keys.T},
                {50, Keys.N},
                {51, Keys.S},
                {52, Keys.OemMinus},
                {53, Keys.Enter},
                {54, Keys.ShiftKey},
                {55, Keys.OemSemicolon},
                {56, Keys.Q},
                {57, Keys.J},
                {58, Keys.K},
                {59, Keys.X},
                {60, Keys.B},
                {61, Keys.M},
                {62, Keys.W},
                {63, Keys.V},
                {64, Keys.Z},
                {65, Keys.ShiftKey},
                {66, Keys.ControlKey},
                {67, Keys.Menu},
                {68, Keys.Alt},
                {69, Keys.Space},
                {70, Keys.Alt},
                {71, Keys.Menu},
                {72, Keys.ControlKey}

            };

            Dictionary<int, Keys> keyShiftCodesInts = new Dictionary<int, Keys>()
            {
                {73, Keys.Oemtilde},
                {74, Keys.D1},
                {75, Keys.D2},
                {76, Keys.D3},
                {77, Keys.D4},
                {78, Keys.D5},
                {79, Keys.D6},
                {80, Keys.D7},
                {81, Keys.D8},
                {82, Keys.D9},
                {83, Keys.D0},
                {84, Keys.OemOpenBrackets},
                {85, Keys.OemCloseBrackets},
                {86, Keys.OemQuotes},
                {87, Keys.Oemcomma},
                {88, Keys.OemPeriod},
                {89, Keys.OemQuestion},
                {90, Keys.Oemplus},
                {91, Keys.OemPipe},
                {92, Keys.OemMinus},
                {93, Keys.OemSemicolon}

            };

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

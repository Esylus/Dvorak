using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            loadCheckBoxNameDictionaries();
            loadCBBox();
        }

        private KeyRandomizer userKeyListObject;
        private Statistics sessionStatistics;
        private GameTimer sessionTimer;
        private FadeTimer pointFade;
        private Focus sessionFocus;
        private bool disableKeyBoard = true;
        private Dictionary<int, CheckBox> numberedCheckBoxNames;
        private Dictionary<int, CheckBox> numberedCheckBoxNamesStateIndeterminate;

       

        public void btnPractice_Click(object sender, EventArgs e)
        {
            startSession();
        }

        private void startSession()
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

        private void loadCheckBoxNameDictionaries()
        {  // On startup, create dictionaries containing a number matched to each checkbox name 

            List<CheckBox> allCheckBoxNames = new List<CheckBox>()
            {
                cbEsc,cbF1,cbF2,cbF3,cbF4,cbF5,cbF6,cbF7,cbF8,cbF9,cbF10,cbF11,cbF12,cbTilda,cb1,
                cb2,cb3,cb4,cb5,cb6,cb7,cb8,cb9,cb0,cbLSqr,cbRSqr,cbBack,cbLTab,cbQte,cbComma,cbPrd,cbP,
                cbY,cbF,cbG,cbC,cbR,cbL,cbFSlsh,cbEql,cbBSlsh,cbCaps,cbA,cbO,cbE,cbU,cbI,cbD,cbH,cbT,cbN,
                cbS,cbDash,cbEntr,cbLShft,cbColon,cbQ,cbJ,cbK,cbX,cbB,cbM,cbW,cbV,cbZ,cbRShft,cbLCtrl,cbStrt,
                cbLAlt,cbSpace,cbLAlt,cbMenu,cbRCtrl
            };

             numberedCheckBoxNames = new Dictionary<int, CheckBox>();

            int count = 0;
            foreach (CheckBox cb in allCheckBoxNames)
            {
                numberedCheckBoxNames.Add(count, cb);
                count++;
            }


            List<CheckBox> allCheckBoxNamesStateIndeterminate = new List<CheckBox>()
            {
                cbTilda,cb1,cb2,cb3,cb4,cb5,cb6,cb7,cb8,cb9,cb0,cbLSqr,cbRSqr,
                cbQte,cbComma,cbPrd,cbFSlsh,cbEql,cbBSlsh,cbDash,cbColon
            };

            numberedCheckBoxNamesStateIndeterminate = new Dictionary<int, CheckBox>();

            int count1 = 73;
            foreach (CheckBox cb in allCheckBoxNamesStateIndeterminate)
            {
                numberedCheckBoxNamesStateIndeterminate.Add(count1, cb);
                count1++;
            }

            foreach (var keyPair in numberedCheckBoxNames)
            {// add first list to second  
                numberedCheckBoxNamesStateIndeterminate.Add(keyPair.Key, keyPair.Value);
            }

        }

        private List<int> putUserSelectedKeysIntoList()
        { // Return a list of all the selected keys user wants to practice with
          // Collect all user-selected checkbox names, look up number in dict, put numbers in a list

            List<int> usersSelectedKeys = new List<int>();

            while ( ! usersSelectedKeys.Any()) 
            {

                foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                {
                    if (cb.CheckState == CheckState.Checked)
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNames)                                                                                     
                        {  // look up checkbox name in Dictionary and add number to list
                            if (cb == keyString.Value)
                            {
                                usersSelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                    else if (cb.CheckState == CheckState.Indeterminate)
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNamesStateIndeterminate) 
                        {  // look up tristate indeterminate checkbox name in Dictionary and add number to list
                            if (cb == keyString.Value)
                            {
                                usersSelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                }              

                if (!usersSelectedKeys.Any()) // EDGE CASE - if no keys selected, select all keys by default          
                    keyCheckBoxSelectAll();
            }

            if (usersSelectedKeys.Count < 2)
            { // EDGE CASE - KeyRandomizer.cs method prevents any key from repeating 
              // if only a single key is selected the below default will select entire home row

                MessageBox.Show("Must select minimum two keys as keys are unable to repeat themselves. " +
                                "Now practice your home row or hit Reset to select again!");
                usersSelectedKeys.Clear();
                keyCheckBoxClear();
                int[] range = {42, 43, 44, 45, 46, 47, 48, 49, 50, 51};               
                usersSelectedKeys.AddRange(range);
                CheckBox[] cbRange = new CheckBox[]{cbA, cbO, cbE, cbU, cbI, cbD, cbH, cbT, cbN, cbS};
                foreach (CheckBox cb in cbRange)
                {
                    cb.Checked = true;
                }
            }
            return usersSelectedKeys;
        }

        private void getRandomKeyAndDisplay()
        { // randomly selects number (in KeyRandomizer.cs) from user selected list, looks up string in dictionary and displays
          // if focus button has been pressed, an optimized focus list will be created after the first round 

            if (sessionFocus != null) 
            {
                if (sessionFocus.FocusModeEnabled)
                { // use focus list accumulated by tracking user performance from first round

                    userKeyListObject.extractUserRandomKeyToMember(sessionFocus.FocusList); 
                }
                else
                { // use normal list for first round to accumulate user performance data

                    userKeyListObject.extractUserRandomKeyToMember(userKeyListObject.UserSelectedKeyList); 
                }
            }
            else
            { // if the focus button is not pressed use normal default list

                userKeyListObject.extractUserRandomKeyToMember(userKeyListObject.UserSelectedKeyList); // Default list
            }

            List<String> allCheckBoxStrings = new List<String>()
            { // FUTURE MAINTENANCE - change display characters here

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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        { // create dictionaries of numbered key codes
          // if user input matches selected key, get new key (which adds to positive score) 
          // if user input is incorrect, add to score

            if (disableKeyBoard)
            {
                return;
            }

            List<Keys> keyCodes = new List<Keys>()
            {
                Keys.Escape,Keys.F1,Keys.F2,Keys.F3,Keys.F4,Keys.F5,Keys.F6,Keys.F7,Keys.F8,Keys.F9,Keys.F10,Keys.F11,Keys.F12,Keys.Oemtilde,
                 Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9,Keys.D0,Keys.OemOpenBrackets,Keys.OemCloseBrackets,
                 Keys.Back,Keys.Tab,Keys.OemQuotes,Keys.Oemcomma,Keys.OemPeriod,Keys.P,Keys.Y,Keys.F,Keys.G,Keys.C,Keys.R,Keys.L,Keys.OemQuestion,
                 Keys.Oemplus,Keys.OemPipe,Keys.CapsLock,Keys.A,Keys.O,Keys.E,Keys.U,Keys.I,Keys.D,Keys.H,Keys.T,Keys.N,Keys.S,Keys.OemMinus,
                 Keys.Enter,Keys.ShiftKey,Keys.OemSemicolon,Keys.Q,Keys.J,Keys.K,Keys.X,Keys.B,Keys.M,Keys.W,Keys.V,Keys.Z,Keys.ShiftKey,Keys.ControlKey,
                 Keys.Menu,Keys.Alt,Keys.Space,Keys.Alt,Keys.Menu,Keys.ControlKey
            };

            Dictionary<int, Keys> numberedKeyCodes = new Dictionary<int, Keys>();
            
                int count3 = 0;
                foreach (Keys key in keyCodes)
                {
                    numberedKeyCodes.Add(count3, key);
                    count3++;
                }            

            List<Keys> shiftKeyCodes = new List<Keys>()   
            {
                Keys.Oemtilde,Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9,Keys.D0,Keys.OemOpenBrackets,Keys.OemCloseBrackets,
                Keys.OemQuotes,Keys.Oemcomma,Keys.OemPeriod,Keys.OemQuestion,Keys.Oemplus,Keys.OemPipe,Keys.OemMinus,Keys.OemSemicolon
            };

            Dictionary<int, Keys> shiftNumberedKeyCodes = new Dictionary<int, Keys>();
          
                int count4 = 73;
                foreach (Keys key in shiftKeyCodes)
                {
                    shiftNumberedKeyCodes.Add(count4, key);
                    count4++;
                }
            

            if (!e.Shift)
            {  
                foreach (KeyValuePair<int, Keys> keyCode in numberedKeyCodes)
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
            {// for key presses that require shift 

                foreach (KeyValuePair<int, Keys> keyCode in shiftNumberedKeyCodes)
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

        //------------------------Game play above, Helper Functions below-------------------------------------------

            private void cbFocus_CheckedChanged(object sender, EventArgs e)
            { // if focus cb checked, initialize focus object. If unchecked, disable bool 

                if (cbFocus.Checked) 
                {
                    sessionFocus = new Focus();
                }
                else
                {
                    sessionFocus.FocusModeEnabled = false; 
                }
            }

            private void playAgain()
            { // user answered correct - collect user performance data  
              // track score + display to user

            if (cbFocus.Checked) // if in focus mode, collect user performance data
                {
                    sessionFocus.recordUserResults(userKeyListObject.CurrentRandomKey, 1);
                }

                sessionStatistics.Correct++;
                sessionStatistics.Total++;
                sessionStatistics.TotalPoints += 5;

                pointFade = new FadeTimer(0, 255, 0); // for green and red score display
                pointFade.PositiveOrNegativePoints = true; 
                FadeTimer.Start(); 

                getScoreAndDisplayStatistics();
                getRandomKeyAndDisplay();
            }

            private void trackTotal() 
            { // user answer incorrect

                if (cbFocus.Checked)
                {
                    sessionFocus.recordUserResults(userKeyListObject.CurrentRandomKey, 0);
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

                if (total != 0) 
                {
                    accuracy = sessionStatistics.calculateAccuracy(correct, total);
                    lblAccuracyDisplay.Text = accuracy.ToString("P");
                }
            }

            private void btnReset_Click(object sender, EventArgs e) 
            {
                statisticDisplaysClear();
                timer1.Stop();
                keyCheckBoxClear();
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

            private void keyCheckBoxClear() 
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

            private void keyCheckBoxSelectAll() 
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

                cbLAlt.Checked = false;  // unselect for various reasons
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

                if (sessionTimer.TimerCount == 0)
                {// when round is over

                    timer1.Stop();
                    lblMain.Text = "Time";
                    disableKeyBoard = true;

                    if (cbFocus.Checked)  
                    { // if focus mode enabled - create focus list based on users first round performance
                        sessionFocus.createFocusList();
                        sessionFocus.FocusModeEnabled = true;
                    }
                }
            }

            private void FadeTimer_Tick(object sender, EventArgs e)
            { // Animation which allows points added or subtracted to fade away

                pointFade.FadeTimerCount--;
                int endColor = 105;
                int fadeRate = 5;

                if (pointFade.PositiveOrNegativePoints)
                { // if positive points apply green color + fade

                    lblPointsDisplay.ForeColor = Color.FromArgb(pointFade.R, pointFade.G, pointFade.B);
                    lblPointsDisplay.Text = "+5";

                    if (pointFade.R < endColor) pointFade.R += fadeRate;
                    if (pointFade.G > endColor) pointFade.G -= fadeRate;
                    if (pointFade.B < endColor) pointFade.B += fadeRate;
                }
                else
                { // if negative points apply red color + fade

                    lblPointsDisplay.ForeColor = Color.FromArgb(pointFade.R, pointFade.G, pointFade.B);
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

            private void cbFingerings_CheckedChanged(object sender, EventArgs e)
                { // toggle colored recommended key fingerings view  

                Fingerings one = new Fingerings(155, 255, 131, 62); // thumb
                Fingerings two = new Fingerings(155, 132, 138, 224); 
                Fingerings three = new Fingerings(155, 149, 73, 203); 
                Fingerings four = new Fingerings(155, 160, 192, 76); 
                Fingerings five = new Fingerings(155, 0, 153, 217); // pinky

                CheckBox[] pinky = new CheckBox[] {cbEsc, cbF11, cbF12, cbTilda, cb1, cbRSqr, cbBack, cbLTab, cbQte,
                                                  cbBSlsh, cbEql, cbFSlsh, cbCaps, cbA, cbS, cbDash, cbEntr, cbLShft,
                                                  cbColon, cbZ, cbRShft, cbLCtrl,cbStrt, cbRCtrl};

                CheckBox[] ring = new CheckBox[] {cbF1, cbF2, cbF3, cbF9, cbF10, cb2, cb3, cb0, cbLSqr, cbComma, cbR,
                                                  cbL, cbO, cbN, cbQ, cbV, cbMenu};

                CheckBox[] middle = new CheckBox[] {cbF4, cbF8, cb4, cb9, cbPrd, cbC, cbE, cbT, cbJ, cbW};

                CheckBox[] pointer = new CheckBox[] {cbF5, cbF6, cbF7, cb5, cb6, cb7, cb8, cbP, cbY, cbF, cbG, cbU, cbI,
                                                     cbD, cbH, cbK, cbX, cbB, cbM};

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

        private void loadCBBox()
        {
            if (File.Exists("DvorakPresets.sqlite"))
            {
                PresetDBHelper.connectToDatabase();
                PresetDBHelper.printPresetsComboBox(cbPreset);
                cbPreset.Text = "Default";
            }
            else
            {

                PresetDBHelper.createNewDatabase();
                PresetDBHelper.connectToDatabase();
                PresetDBHelper.createTable();
                PresetDBHelper.InsertDefault();
                PresetDBHelper.printPresetsComboBox(cbPreset);
                cbPreset.Text = "Default";
            }
        }

        private void refreshCBBox()
        {
            cbPreset.Items.Clear();
            PresetDBHelper.connectToDatabase();
            PresetDBHelper.printPresetsComboBox(cbPreset);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  // gather all user selected keys and look up in dictionary to get the int value
           // add int to list to make a user list saved as a string
           // put string and name of string into preset object and save to db

            try
            {
                List<int> saveUsersSelectedKeys = new List<int>();
       
                foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
                {
                    if (cb.CheckState == CheckState.Checked)
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNames)
                        {
                            // look up checkbox name in Dictionary and add number to list
                            if (cb == keyString.Value)
                            {
                                saveUsersSelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                    else if (cb.CheckState == CheckState.Indeterminate)
                    {
                        foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNamesStateIndeterminate)
                        {  // look up tristate indeterminate checkbox name in Dictionary and add number to list
                            if (cb == keyString.Value)
                            {
                                saveUsersSelectedKeys.Add(keyString.Key);
                            }
                        }
                    }
                }

                string myPresetList = "";
                string name = cbPreset.Text;
             
                foreach (int keyNum in saveUsersSelectedKeys)
                {
                    myPresetList += keyNum.ToString() + " ";
                }

                if (string.IsNullOrEmpty(name) || (string.IsNullOrEmpty(myPresetList)))
                {
                    throw new ApplicationException();  // to ensure that blank presets are not saved
                    
                }

                Preset newPreset = new Preset(name, myPresetList);
             
                PresetDBHelper.connectToDatabase();
                PresetDBHelper.InsertDB(newPreset);
                refreshCBBox();
                MessageBox.Show("New Preset Created ");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Saving preset requires a name and keys selected ");
            }
     }

        private void cbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            string preset = "";

            PresetDBHelper.connectToDatabase();
            preset = PresetDBHelper.getPresetList(cbPreset.Text);    

            preset = preset.TrimEnd();
            string[] presetStrings = preset.Split();

            List<int> presetInts = new List<int>();

            foreach (string str in presetStrings)
            {                
                presetInts.Add(Convert.ToInt32(str));                
            }
          
            foreach (CheckBox cb in gbKeyBoard.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;
            }


            foreach (int cbInt in presetInts)
            {
                foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNames)
                {
                    // look up checkbox name in Dictionary and add number to list
                    if (cbInt == keyString.Key)
                    {
                        keyString.Value.Checked = true;
                    }
                }
                foreach (KeyValuePair<int, CheckBox> keyString in numberedCheckBoxNamesStateIndeterminate)
                {
                    // look up checkbox name in Dictionary and add number to list
                    if ((cbInt > 72) && (cbInt == keyString.Key))
                    {
                        keyString.Value.CheckState = CheckState.Indeterminate;
                    }
                }
            }
        }
    }
}

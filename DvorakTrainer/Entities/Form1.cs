﻿using System;
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
        private bool disableKeyBoard = true;

        public void btnPractice_Click(object sender, EventArgs e)
        {
            startSession();
        }

        private void startSession()           // initiates practice session 
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

        private List<int> putUserSelectedKeysIntoList()     // Return a list of all selected keys 
        {
            List<int> mySelectedKeys = new List<int>();

            while (!mySelectedKeys.Any())  // ensures that the list will never be empty
            {               
                if (cbEsc.Checked == true) { mySelectedKeys.Add(0); }
                if (cbF1.Checked == true) { mySelectedKeys.Add(1); }
                if (cbF2.Checked == true) { mySelectedKeys.Add(2); }
                if (cbF3.Checked == true) { mySelectedKeys.Add(3); }
                if (cbF4.Checked == true) { mySelectedKeys.Add(4); }
                if (cbF5.Checked == true) { mySelectedKeys.Add(5); }
                if (cbF6.Checked == true) { mySelectedKeys.Add(6); }
                if (cbF7.Checked == true) { mySelectedKeys.Add(7); }
                if (cbF8.Checked == true) { mySelectedKeys.Add(8); }
                if (cbF9.Checked == true) { mySelectedKeys.Add(9); }
                if (cbF10.Checked == true) { mySelectedKeys.Add(10); }
                if (cbF11.Checked == true) { mySelectedKeys.Add(11); }
                if (cbF12.Checked == true) { mySelectedKeys.Add(12); }
                if (cbTilda.CheckState == CheckState.Checked) { mySelectedKeys.Add(13); }
                if (cb1.CheckState == CheckState.Checked) { mySelectedKeys.Add(14); }
                if (cb2.CheckState == CheckState.Checked) { mySelectedKeys.Add(15); }
                if (cb3.CheckState == CheckState.Checked) { mySelectedKeys.Add(16); }
                if (cb4.CheckState == CheckState.Checked) { mySelectedKeys.Add(17); }
                if (cb5.CheckState == CheckState.Checked) { mySelectedKeys.Add(18); }
                if (cb6.CheckState == CheckState.Checked) { mySelectedKeys.Add(19); }
                if (cb7.CheckState == CheckState.Checked) { mySelectedKeys.Add(20); }
                if (cb8.CheckState == CheckState.Checked) { mySelectedKeys.Add(21); }
                if (cb9.CheckState == CheckState.Checked) { mySelectedKeys.Add(22); }
                if (cb0.CheckState == CheckState.Checked) { mySelectedKeys.Add(23); }
                if (cbLSqr.CheckState == CheckState.Checked) { mySelectedKeys.Add(24); }
                if (cbRSqr.CheckState == CheckState.Checked) { mySelectedKeys.Add(25); }
                if (cbBack.Checked == true) { mySelectedKeys.Add(26); }
                if (cbLTab.Checked == true) { mySelectedKeys.Add(27); }
                if (cbQte.CheckState == CheckState.Checked) { mySelectedKeys.Add(28); }
                if (cbComma.CheckState == CheckState.Checked) { mySelectedKeys.Add(29); }
                if (cbPrd.CheckState == CheckState.Checked) { mySelectedKeys.Add(30); }
                if (cbP.Checked == true) { mySelectedKeys.Add(31); }
                if (cbY.Checked == true) { mySelectedKeys.Add(32); }
                if (cbF.Checked == true) { mySelectedKeys.Add(33); }
                if (cbG.Checked == true) { mySelectedKeys.Add(34); }
                if (cbC.Checked == true) { mySelectedKeys.Add(35); }
                if (cbR.Checked == true) { mySelectedKeys.Add(36); }
                if (cbL.Checked == true) { mySelectedKeys.Add(37); }
                if (cbBSlsh.CheckState == CheckState.Checked) { mySelectedKeys.Add(38); }
                if (cbEql.CheckState == CheckState.Checked) { mySelectedKeys.Add(39); }
                if (cbFSlsh.CheckState == CheckState.Checked) { mySelectedKeys.Add(40); }
                if (cbCaps.Checked == true) { mySelectedKeys.Add(41); }
                if (cbA.Checked == true) { mySelectedKeys.Add(42); }
                if (cbO.Checked == true) { mySelectedKeys.Add(43); }
                if (cbE.Checked == true) { mySelectedKeys.Add(44); }
                if (cbU.Checked == true) { mySelectedKeys.Add(45); }
                if (cbI.Checked == true) { mySelectedKeys.Add(46); }
                if (cbD.Checked == true) { mySelectedKeys.Add(47); }
                if (cbH.Checked == true) { mySelectedKeys.Add(48); }
                if (cbT.Checked == true) { mySelectedKeys.Add(49); }
                if (cbN.Checked == true) { mySelectedKeys.Add(50); }
                if (cbS.Checked == true) { mySelectedKeys.Add(51); }
                if (cbDash.CheckState == CheckState.Checked) { mySelectedKeys.Add(52); }
                if (cbEntr.Checked == true) { mySelectedKeys.Add(53); }
                if (cbLShft.Checked == true) { mySelectedKeys.Add(54); }
                if (cbColon.CheckState == CheckState.Checked) { mySelectedKeys.Add(55); }
                if (cbQ.Checked == true) { mySelectedKeys.Add(56); }
                if (cbJ.Checked == true) { mySelectedKeys.Add(57); }
                if (cbK.Checked == true) { mySelectedKeys.Add(58); }
                if (cbX.Checked == true) { mySelectedKeys.Add(59); }
                if (cbB.Checked == true) { mySelectedKeys.Add(60); }
                if (cbM.Checked == true) { mySelectedKeys.Add(61); }
                if (cbW.Checked == true) { mySelectedKeys.Add(62); }
                if (cbV.Checked == true) { mySelectedKeys.Add(63); }
                if (cbZ.Checked == true) { mySelectedKeys.Add(64); }
                if (cbRShft.Checked == true) { mySelectedKeys.Add(65); }
                if (cbLCtrl.Checked == true) { mySelectedKeys.Add(66); }
                if (cbStrt.Checked == true) { mySelectedKeys.Add(67); }
                if (cbLAlt.Checked == true) { mySelectedKeys.Add(68); }
                if (cbSpace.Checked == true) { mySelectedKeys.Add(69); }
                if (cbRAlt.Checked == true) { mySelectedKeys.Add(70); }
                if (cbMenu.Checked == true) { mySelectedKeys.Add(71); }
                if (cbRCtrl.Checked == true) { mySelectedKeys.Add(72); }
                if (cbTilda.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(13); mySelectedKeys.Add(73); }
                if (cb1.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(14); mySelectedKeys.Add(74); }
                if (cb2.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(15); mySelectedKeys.Add(75); }
                if (cb3.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(16); mySelectedKeys.Add(76); }
                if (cb4.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(17); mySelectedKeys.Add(77); }
                if (cb5.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(18); mySelectedKeys.Add(78); }
                if (cb6.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(19); mySelectedKeys.Add(79); }
                if (cb7.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(20); mySelectedKeys.Add(80); }
                if (cb8.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(21); mySelectedKeys.Add(81); }
                if (cb9.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(22); mySelectedKeys.Add(82); }
                if (cb0.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(23); mySelectedKeys.Add(83); }
                if (cbLSqr.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(24); mySelectedKeys.Add(84); }
                if (cbRSqr.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(25); mySelectedKeys.Add(85); }
                if (cbQte.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(28); mySelectedKeys.Add(86); }
                if (cbComma.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(29); mySelectedKeys.Add(87); }
                if (cbPrd.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(30); mySelectedKeys.Add(88); }
                if (cbBSlsh.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(38); mySelectedKeys.Add(89); }
                if (cbEql.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(39); mySelectedKeys.Add(90); }
                if (cbFSlsh.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(40); mySelectedKeys.Add(91); }
                if (cbDash.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(52); mySelectedKeys.Add(92); }
                if (cbColon.CheckState == CheckState.Indeterminate) { mySelectedKeys.Add(55); mySelectedKeys.Add(93); }

                if (!mySelectedKeys.Any()) // if no keys selected up to now, select all keys           
                    keysAll();                        
            }

            return mySelectedKeys;
        }

        private void getRandomKeyAndDisplay() //Gets random key from user selected list and displays
        {            
            userKeyListObject.extractUserRandomKeyToMember();

            switch (userKeyListObject.CurrentRandomKey)
            {
                case 0: lblMain.Text = "Esc"; break;
                case 1: lblMain.Text = "F1"; break;
                case 2: lblMain.Text = "F2"; break;
                case 3: lblMain.Text = "F3"; break;
                case 4: lblMain.Text = "F4"; break;
                case 5: lblMain.Text = "F5"; break;
                case 6: lblMain.Text = "F6"; break;
                case 7: lblMain.Text = "F7"; break;
                case 8: lblMain.Text = "F8"; break;
                case 9: lblMain.Text = "F9"; break;
                case 10: lblMain.Text = "F10"; break;
                case 11: lblMain.Text = "F11"; break;
                case 12: lblMain.Text = "F12"; break;
                case 13: lblMain.Text = "`"; break;
                case 14: lblMain.Text = "1"; break;
                case 15: lblMain.Text = "2"; break;
                case 16: lblMain.Text = "3"; break;
                case 17: lblMain.Text = "4"; break;
                case 18: lblMain.Text = "5"; break;
                case 19: lblMain.Text = "6"; break;
                case 20: lblMain.Text = "7"; break;
                case 21: lblMain.Text = "8"; break;
                case 22: lblMain.Text = "9"; break;
                case 23: lblMain.Text = "0"; break;
                case 24: lblMain.Text = "["; break;
                case 25: lblMain.Text = "]"; break;
                case 26: lblMain.Text = "Back"; break;
                case 27: lblMain.Text = "Tab"; break;
                case 28: lblMain.Text = "'"; break;
                case 29: lblMain.Text = ","; break;
                case 30: lblMain.Text = "."; break;
                case 31: lblMain.Text = "p"; break;
                case 32: lblMain.Text = "y"; break;
                case 33: lblMain.Text = "f"; break;
                case 34: lblMain.Text = "g"; break;
                case 35: lblMain.Text = "c"; break;
                case 36: lblMain.Text = "r"; break;
                case 37: lblMain.Text = "l"; break;
                case 38: lblMain.Text = "/"; break;
                case 39: lblMain.Text = "="; break;
                case 40: lblMain.Text = "\\"; break;
                case 41: lblMain.Text = "Caps"; break;
                case 42: lblMain.Text = "a"; break;
                case 43: lblMain.Text = "o"; break;
                case 44: lblMain.Text = "e"; break;
                case 45: lblMain.Text = "u"; break;
                case 46: lblMain.Text = "i"; break;
                case 47: lblMain.Text = "d"; break;
                case 48: lblMain.Text = "h"; break;
                case 49: lblMain.Text = "t"; break;
                case 50: lblMain.Text = "n"; break;
                case 51: lblMain.Text = "s"; break;
                case 52: lblMain.Text = "-"; break;
                case 53: lblMain.Text = "Enter"; break;
                case 54: lblMain.Text = "Shift"; break;
                case 55: lblMain.Text = ";"; break;
                case 56: lblMain.Text = "q"; break;
                case 57: lblMain.Text = "j"; break;
                case 58: lblMain.Text = "k"; break;
                case 59: lblMain.Text = "x"; break;
                case 60: lblMain.Text = "b"; break;
                case 61: lblMain.Text = "m"; break;
                case 62: lblMain.Text = "w"; break;
                case 63: lblMain.Text = "v"; break;
                case 64: lblMain.Text = "z"; break;
                case 65: lblMain.Text = "Shift"; break;
                case 66: lblMain.Text = "Ctrl"; break;
                case 67: lblMain.Text = "Start"; break;
                case 68: lblMain.Text = "Alt"; break;
                case 69: lblMain.Text = "Space"; break;
                case 70: lblMain.Text = "Alt"; break;
                case 71: lblMain.Text = "Menu"; break;
                case 72: lblMain.Text = "Ctrl"; break;
                case 73: lblMain.Text = "~"; break;
                case 74: lblMain.Text = "!"; break;
                case 75: lblMain.Text = "@"; break;
                case 76: lblMain.Text = "#"; break;
                case 77: lblMain.Text = "$"; break;
                case 78: lblMain.Text = "%"; break;
                case 79: lblMain.Text = "^"; break;
                case 80: lblMain.Text = "&&"; break;
                case 81: lblMain.Text = "*"; break;
                case 82: lblMain.Text = "("; break;
                case 83: lblMain.Text = ")"; break;
                case 84: lblMain.Text = "{"; break;
                case 85: lblMain.Text = "}"; break;
                case 86: lblMain.Text = "\""; break;
                case 87: lblMain.Text = "<"; break;
                case 88: lblMain.Text = ">"; break;
                case 89: lblMain.Text = "?"; break;
                case 90: lblMain.Text = "+"; break;
                case 91: lblMain.Text = "|"; break;
                case 92: lblMain.Text = "_"; break;
                case 93: lblMain.Text = ":"; break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) //TRACK USER INTERACTION - if user input matches selected key, tally score and get new key 
        {
            if (disableKeyBoard)
            { return; }


            if (!e.Shift)      // for key presses without shift 
            {
                if ((e.KeyCode == Keys.Escape) && (userKeyListObject.CurrentRandomKey == 0)) { playAgain(); }
                else if ((e.KeyCode == Keys.F1) && (userKeyListObject.CurrentRandomKey == 1)) { playAgain(); }
                else if ((e.KeyCode == Keys.F2) && (userKeyListObject.CurrentRandomKey == 2)) { playAgain(); }
                else if ((e.KeyCode == Keys.F3) && (userKeyListObject.CurrentRandomKey == 3)) { playAgain(); }
                else if ((e.KeyCode == Keys.F4) && (userKeyListObject.CurrentRandomKey == 4)) { playAgain(); }
                else if ((e.KeyCode == Keys.F5) && (userKeyListObject.CurrentRandomKey == 5)) { playAgain(); }
                else if ((e.KeyCode == Keys.F6) && (userKeyListObject.CurrentRandomKey == 6)) { playAgain(); }
                else if ((e.KeyCode == Keys.F7) && (userKeyListObject.CurrentRandomKey == 7)) { playAgain(); }
                else if ((e.KeyCode == Keys.F8) && (userKeyListObject.CurrentRandomKey == 8)) { playAgain(); }
                else if ((e.KeyCode == Keys.F9) && (userKeyListObject.CurrentRandomKey == 9)) { playAgain(); }
                else if ((e.KeyCode == Keys.F10) && (userKeyListObject.CurrentRandomKey == 10)) { playAgain(); }
                else if ((e.KeyCode == Keys.F11) && (userKeyListObject.CurrentRandomKey == 11)) { playAgain(); }
                else if ((e.KeyCode == Keys.F12) && (userKeyListObject.CurrentRandomKey == 12)) { playAgain(); }
                else if ((e.KeyCode == Keys.Oemtilde) && (userKeyListObject.CurrentRandomKey == 13)) { playAgain(); }
                else if ((e.KeyCode == Keys.D1) && (userKeyListObject.CurrentRandomKey == 14)) { playAgain(); }
                else if ((e.KeyCode == Keys.D2) && (userKeyListObject.CurrentRandomKey == 15)) { playAgain(); }
                else if ((e.KeyCode == Keys.D3) && (userKeyListObject.CurrentRandomKey == 16)) { playAgain(); }
                else if ((e.KeyCode == Keys.D4) && (userKeyListObject.CurrentRandomKey == 17)) { playAgain(); }
                else if ((e.KeyCode == Keys.D5) && (userKeyListObject.CurrentRandomKey == 18)) { playAgain(); }
                else if ((e.KeyCode == Keys.D6) && (userKeyListObject.CurrentRandomKey == 19)) { playAgain(); }
                else if ((e.KeyCode == Keys.D7) && (userKeyListObject.CurrentRandomKey == 20)) { playAgain(); }
                else if ((e.KeyCode == Keys.D8) && (userKeyListObject.CurrentRandomKey == 21)) { playAgain(); }
                else if ((e.KeyCode == Keys.D9) && (userKeyListObject.CurrentRandomKey == 22)) { playAgain(); }
                else if ((e.KeyCode == Keys.D0) && (userKeyListObject.CurrentRandomKey == 23)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemOpenBrackets) && (userKeyListObject.CurrentRandomKey == 24)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemCloseBrackets) && (userKeyListObject.CurrentRandomKey == 25)) { playAgain(); }
                else if ((e.KeyCode == Keys.Back) && (userKeyListObject.CurrentRandomKey == 26)) { playAgain(); }
                else if ((e.KeyCode == Keys.Tab) && (userKeyListObject.CurrentRandomKey == 27)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemQuotes) && (userKeyListObject.CurrentRandomKey == 28)) { playAgain(); }
                else if ((e.KeyCode == Keys.Oemcomma) && (userKeyListObject.CurrentRandomKey == 29)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemPeriod) && (userKeyListObject.CurrentRandomKey == 30)) { playAgain(); }
                else if ((e.KeyCode == Keys.P) && (userKeyListObject.CurrentRandomKey == 31)) { playAgain(); }
                else if ((e.KeyCode == Keys.Y) && (userKeyListObject.CurrentRandomKey == 32)) { playAgain(); }
                else if ((e.KeyCode == Keys.F) && (userKeyListObject.CurrentRandomKey == 33)) { playAgain(); }
                else if ((e.KeyCode == Keys.G) && (userKeyListObject.CurrentRandomKey == 34)) { playAgain(); }
                else if ((e.KeyCode == Keys.C) && (userKeyListObject.CurrentRandomKey == 35)) { playAgain(); }
                else if ((e.KeyCode == Keys.R) && (userKeyListObject.CurrentRandomKey == 36)) { playAgain(); }
                else if ((e.KeyCode == Keys.L) && (userKeyListObject.CurrentRandomKey == 37)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemQuestion) && (userKeyListObject.CurrentRandomKey == 38)) { playAgain(); }
                else if ((e.KeyCode == Keys.Oemplus) && (userKeyListObject.CurrentRandomKey == 39)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemPipe) && (userKeyListObject.CurrentRandomKey == 40)) { playAgain(); }
                else if ((e.KeyCode == Keys.CapsLock) && (userKeyListObject.CurrentRandomKey == 41)) { playAgain(); }
                else if ((e.KeyCode == Keys.A) && (userKeyListObject.CurrentRandomKey == 42)) { playAgain(); }
                else if ((e.KeyCode == Keys.O) && (userKeyListObject.CurrentRandomKey == 43)) { playAgain(); }
                else if ((e.KeyCode == Keys.E) && (userKeyListObject.CurrentRandomKey == 44)) { playAgain(); }
                else if ((e.KeyCode == Keys.U) && (userKeyListObject.CurrentRandomKey == 45)) { playAgain(); }
                else if ((e.KeyCode == Keys.I) && (userKeyListObject.CurrentRandomKey == 46)) { playAgain(); }
                else if ((e.KeyCode == Keys.D) && (userKeyListObject.CurrentRandomKey == 47)) { playAgain(); }
                else if ((e.KeyCode == Keys.H) && (userKeyListObject.CurrentRandomKey == 48)) { playAgain(); }
                else if ((e.KeyCode == Keys.T) && (userKeyListObject.CurrentRandomKey == 49)) { playAgain(); }
                else if ((e.KeyCode == Keys.N) && (userKeyListObject.CurrentRandomKey == 50)) { playAgain(); }
                else if ((e.KeyCode == Keys.S) && (userKeyListObject.CurrentRandomKey == 51)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemMinus) && (userKeyListObject.CurrentRandomKey == 52)) { playAgain(); }
                else if ((e.KeyCode == Keys.Enter) && (userKeyListObject.CurrentRandomKey == 53)) { playAgain(); }
                else if ((e.KeyCode == Keys.ShiftKey) && (userKeyListObject.CurrentRandomKey == 54)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemSemicolon) && (userKeyListObject.CurrentRandomKey == 55)) { playAgain(); }
                else if ((e.KeyCode == Keys.Q) && (userKeyListObject.CurrentRandomKey == 56)) { playAgain(); }
                else if ((e.KeyCode == Keys.J) && (userKeyListObject.CurrentRandomKey == 57)) { playAgain(); }
                else if ((e.KeyCode == Keys.K) && (userKeyListObject.CurrentRandomKey == 58)) { playAgain(); }
                else if ((e.KeyCode == Keys.X) && (userKeyListObject.CurrentRandomKey == 59)) { playAgain(); }
                else if ((e.KeyCode == Keys.B) && (userKeyListObject.CurrentRandomKey == 60)) { playAgain(); }
                else if ((e.KeyCode == Keys.M) && (userKeyListObject.CurrentRandomKey == 61)) { playAgain(); }
                else if ((e.KeyCode == Keys.W) && (userKeyListObject.CurrentRandomKey == 62)) { playAgain(); }
                else if ((e.KeyCode == Keys.V) && (userKeyListObject.CurrentRandomKey == 63)) { playAgain(); }
                else if ((e.KeyCode == Keys.Z) && (userKeyListObject.CurrentRandomKey == 64)) { playAgain(); }
                else if ((e.KeyCode == Keys.ShiftKey) && (userKeyListObject.CurrentRandomKey == 65)) { playAgain(); }
                else if ((e.KeyCode == Keys.ControlKey) && (userKeyListObject.CurrentRandomKey == 66)) { playAgain(); }
                else if ((e.KeyCode == Keys.Menu) && (userKeyListObject.CurrentRandomKey == 67)) { playAgain(); }
                else if ((e.KeyCode == Keys.Alt) && (userKeyListObject.CurrentRandomKey == 68)) { playAgain(); }
                else if ((e.KeyCode == Keys.Space) && (userKeyListObject.CurrentRandomKey == 69)) { playAgain(); }
                else if ((e.KeyCode == Keys.Alt) && (userKeyListObject.CurrentRandomKey == 70)) { playAgain(); }
                else if ((e.KeyCode == Keys.Menu) && (userKeyListObject.CurrentRandomKey == 71)) { playAgain(); }
                else if ((e.KeyCode == Keys.ControlKey) && (userKeyListObject.CurrentRandomKey == 72)) { playAgain(); }
            }

            else     // for key presses that require shift
            {
                if ((e.KeyCode == Keys.Oemtilde && e.Shift) && (userKeyListObject.CurrentRandomKey == 73)) { playAgain(); }
                else if ((e.KeyCode == Keys.D1 && e.Shift) && (userKeyListObject.CurrentRandomKey == 74)) { playAgain(); }
                else if ((e.KeyCode == Keys.D2 && e.Shift) && (userKeyListObject.CurrentRandomKey == 75)) { playAgain(); }
                else if ((e.KeyCode == Keys.D3 && e.Shift) && (userKeyListObject.CurrentRandomKey == 76)) { playAgain(); }
                else if ((e.KeyCode == Keys.D4 && e.Shift) && (userKeyListObject.CurrentRandomKey == 77)) { playAgain(); }
                else if ((e.KeyCode == Keys.D5 && e.Shift) && (userKeyListObject.CurrentRandomKey == 78)) { playAgain(); }
                else if ((e.KeyCode == Keys.D6 && e.Shift) && (userKeyListObject.CurrentRandomKey == 79)) { playAgain(); }
                else if ((e.KeyCode == Keys.D7 && e.Shift) && (userKeyListObject.CurrentRandomKey == 80)) { playAgain(); }
                else if ((e.KeyCode == Keys.D8 && e.Shift) && (userKeyListObject.CurrentRandomKey == 81)) { playAgain(); }
                else if ((e.KeyCode == Keys.D9 && e.Shift) && (userKeyListObject.CurrentRandomKey == 82)) { playAgain(); }
                else if ((e.KeyCode == Keys.D0 && e.Shift) && (userKeyListObject.CurrentRandomKey == 83)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemOpenBrackets && e.Shift) && (userKeyListObject.CurrentRandomKey == 84)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemCloseBrackets && e.Shift) && (userKeyListObject.CurrentRandomKey == 85)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemQuotes && e.Shift) && (userKeyListObject.CurrentRandomKey == 86)) { playAgain(); }
                else if ((e.KeyCode == Keys.Oemcomma && e.Shift) && (userKeyListObject.CurrentRandomKey == 87)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemPeriod && e.Shift) && (userKeyListObject.CurrentRandomKey == 88)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemQuestion && e.Shift) && (userKeyListObject.CurrentRandomKey == 89)) { playAgain(); }
                else if ((e.KeyCode == Keys.Oemplus && e.Shift) && (userKeyListObject.CurrentRandomKey == 90)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemPipe && e.Shift) && (userKeyListObject.CurrentRandomKey == 91)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemMinus && e.Shift) && (userKeyListObject.CurrentRandomKey == 92)) { playAgain(); }
                else if ((e.KeyCode == Keys.OemSemicolon && e.Shift) && (userKeyListObject.CurrentRandomKey == 93)) { playAgain(); }

                else if ((e.KeyCode == Keys.Back && e.Shift) && (userKeyListObject.CurrentRandomKey == 1000))
                {// this hotkey combo (Shift + Backspace) same as "pressing Practice button"

                    startSession();
                }
            }

            if (!e.Shift)       // To track incorrect key presses that don't require shift
            {
                if (e.KeyCode == Keys.Escape) { trackTotal(); }
                else if (e.KeyCode == Keys.F1) { trackTotal(); }
                else if (e.KeyCode == Keys.F2) { trackTotal(); }
                else if (e.KeyCode == Keys.F3) { trackTotal(); }
                else if (e.KeyCode == Keys.F4) { trackTotal(); }
                else if (e.KeyCode == Keys.F5) { trackTotal(); }
                else if (e.KeyCode == Keys.F6) { trackTotal(); }
                else if (e.KeyCode == Keys.F7) { trackTotal(); }
                else if (e.KeyCode == Keys.F8) { trackTotal(); }
                else if (e.KeyCode == Keys.F9) { trackTotal(); }
                else if (e.KeyCode == Keys.F10) { trackTotal(); }
                else if (e.KeyCode == Keys.F11) { trackTotal(); }
                else if (e.KeyCode == Keys.F12) { trackTotal(); }
                else if (e.KeyCode == Keys.Oemtilde) { trackTotal(); }
                else if (e.KeyCode == Keys.D1) { trackTotal(); }
                else if (e.KeyCode == Keys.D2) { trackTotal(); }
                else if (e.KeyCode == Keys.D3) { trackTotal(); }
                else if (e.KeyCode == Keys.D4) { trackTotal(); }
                else if (e.KeyCode == Keys.D5) { trackTotal(); }
                else if (e.KeyCode == Keys.D6) { trackTotal(); }
                else if (e.KeyCode == Keys.D7) { trackTotal(); }
                else if (e.KeyCode == Keys.D8) { trackTotal(); }
                else if (e.KeyCode == Keys.D9) { trackTotal(); }
                else if (e.KeyCode == Keys.D0) { trackTotal(); }
                else if (e.KeyCode == Keys.OemOpenBrackets) { trackTotal(); }
                else if (e.KeyCode == Keys.OemCloseBrackets) { trackTotal(); }
                else if (e.KeyCode == Keys.Back) { trackTotal(); }
                else if (e.KeyCode == Keys.Tab) { trackTotal(); }
                else if (e.KeyCode == Keys.OemQuotes) { trackTotal(); }
                else if (e.KeyCode == Keys.Oemcomma) { trackTotal(); }
                else if (e.KeyCode == Keys.OemPeriod) { trackTotal(); }
                else if (e.KeyCode == Keys.P) { trackTotal(); }
                else if (e.KeyCode == Keys.Y) { trackTotal(); }
                else if (e.KeyCode == Keys.F) { trackTotal(); }
                else if (e.KeyCode == Keys.G) { trackTotal(); }
                else if (e.KeyCode == Keys.C) { trackTotal(); }
                else if (e.KeyCode == Keys.R) { trackTotal(); }
                else if (e.KeyCode == Keys.L) { trackTotal(); }
                else if (e.KeyCode == Keys.OemQuestion) { trackTotal(); }
                else if (e.KeyCode == Keys.Oemplus) { trackTotal(); }
                else if (e.KeyCode == Keys.OemPipe) { trackTotal(); }
                else if (e.KeyCode == Keys.CapsLock) { trackTotal(); }
                else if (e.KeyCode == Keys.A) { trackTotal(); }
                else if (e.KeyCode == Keys.O) { trackTotal(); }
                else if (e.KeyCode == Keys.E) { trackTotal(); }
                else if (e.KeyCode == Keys.U) { trackTotal(); }
                else if (e.KeyCode == Keys.I) { trackTotal(); }
                else if (e.KeyCode == Keys.D) { trackTotal(); }
                else if (e.KeyCode == Keys.H) { trackTotal(); }
                else if (e.KeyCode == Keys.T) { trackTotal(); }
                else if (e.KeyCode == Keys.N) { trackTotal(); }
                else if (e.KeyCode == Keys.S) { trackTotal(); }
                else if (e.KeyCode == Keys.OemMinus) { trackTotal(); }
                else if (e.KeyCode == Keys.Enter) { trackTotal(); }
                else if (e.KeyCode == Keys.ShiftKey) { trackTotal(); }
                else if (e.KeyCode == Keys.OemSemicolon) { trackTotal(); }
                else if (e.KeyCode == Keys.Q) { trackTotal(); }
                else if (e.KeyCode == Keys.J) { trackTotal(); }
                else if (e.KeyCode == Keys.K) { trackTotal(); }
                else if (e.KeyCode == Keys.X) { trackTotal(); }
                else if (e.KeyCode == Keys.B) { trackTotal(); }
                else if (e.KeyCode == Keys.M) { trackTotal(); }
                else if (e.KeyCode == Keys.W) { trackTotal(); }
                else if (e.KeyCode == Keys.V) { trackTotal(); }
                else if (e.KeyCode == Keys.Z) { trackTotal(); }
                else if (e.KeyCode == Keys.ShiftKey) { trackTotal(); }
                else if (e.KeyCode == Keys.ControlKey) { trackTotal(); }
                else if (e.KeyCode == Keys.Menu) { trackTotal(); }
               // else if (e.KeyCode == Keys.Space) { trackTotal(); }
                else if (e.Alt) { trackTotal(); }
                else if (e.KeyCode == Keys.Menu) { trackTotal(); }
            }

            else // To track incorrect key presses that require shift
            {   //in this case,  getScoreAndDisplayStatistics as total gets incremented by "shift" trackTotal() above

                if (e.KeyCode == Keys.Oemtilde && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D1 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D2 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D3 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D4 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D5 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D6 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D7 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D8 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D9 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.D0 && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemOpenBrackets && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemCloseBrackets && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemQuestion && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.Oemplus && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemPipe && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemMinus && e.Shift) { getScoreAndDisplayStatistics(); }
                if (e.KeyCode == Keys.OemSemicolon && e.Shift) { getScoreAndDisplayStatistics(); }
            }
        }

        private void playAgain()   // add point to correct / +8 to points, get next key
        {
            sessionStatistics.Correct++;

            sessionStatistics.TotalPoints += 8;
            sessionStatistics.PositivePointMonitor = true;
            getRandomKeyAndDisplay();
        }

        private void trackTotal()  // add point to total / -3 to points when user answer incorrect, refresh statistics display
        {
            sessionStatistics.Total++;

            sessionStatistics.TotalPoints -= 3;


            if (sessionStatistics.PositivePointMonitor)  // if positive point signaled 
            {
                pointFade = new FadeTimer(0, 255, 0);            // create fade object
                pointFade.PositiveOrNegativePoints = true;       // assign positive bool
                FadeTimer.Start();                               //start timer which will display points then fade
                sessionStatistics.PositivePointMonitor = false;  //change back to default false
            }
            else
            {
                pointFade = new FadeTimer(255, 0, 0);
                pointFade.PositiveOrNegativePoints = false;
                FadeTimer.Start();          
            }

            getScoreAndDisplayStatistics();
        }   

        private void getScoreAndDisplayStatistics()
        {
            
                decimal correct = sessionStatistics.Correct;
                decimal total = sessionStatistics.Total;
                decimal accuracy = sessionStatistics.Accuracy;
                int totalPoints = sessionStatistics.TotalPoints;

                lblTotalDisplay.Text = totalPoints.ToString();

            if (total != 0)   // only calculate score after minimum 1 key is pressed
                {
                    accuracy = sessionStatistics.calculateAccuracy(correct, total);
                    lblAccuracyDisplay.Text = accuracy.ToString("P");
            }
                    
        }

        private void btnReset_Click(object sender, EventArgs e)  // reset game to initialized state
        {
            statisticDisplaysClear();
            timer1.Stop();
            keysClear();
            disableKeyBoard = true;
            lblDvorak.Show();
        }

        private void statisticDisplaysClear()
        {

            lblPointsDisplay.Text = "";
            lblAccuracyDisplay.Text = "";
            lblTotalDisplay.Text = "";
            lblTimerDisplay.Text = "";
        }

        private void keysClear()    // clear all checkButtons
        {
     
            lblMain.Hide();
            lblDvorak.Show();
            cbEsc.Checked = false;
            cbF1.Checked = false;
            cbF2.Checked = false;
            cbF3.Checked = false;
            cbF4.Checked = false;
            cbF5.Checked = false;
            cbF6.Checked = false;
            cbF7.Checked = false;
            cbF8.Checked = false;
            cbF9.Checked = false;
            cbF10.Checked = false;
            cbF11.Checked = false;
            cbF12.Checked = false;
            cbTilda.CheckState = CheckState.Unchecked;
            cb1.CheckState = CheckState.Unchecked;
            cb2.CheckState = CheckState.Unchecked;
            cb3.CheckState = CheckState.Unchecked;
            cb4.CheckState = CheckState.Unchecked;
            cb5.CheckState = CheckState.Unchecked;
            cb6.CheckState = CheckState.Unchecked;
            cb7.CheckState = CheckState.Unchecked;
            cb8.CheckState = CheckState.Unchecked;
            cb9.CheckState = CheckState.Unchecked;
            cb0.CheckState = CheckState.Unchecked;
            cbLSqr.CheckState = CheckState.Unchecked;
            cbRSqr.CheckState = CheckState.Unchecked;
            cbBack.Checked = false;
            cbLTab.Checked = false;
            cbQte.CheckState = CheckState.Unchecked;
            cbComma.CheckState = CheckState.Unchecked;
            cbPrd.CheckState = CheckState.Unchecked;
            cbP.Checked = false;
            cbY.Checked = false;
            cbF.Checked = false;
            cbG.Checked = false;
            cbC.Checked = false;
            cbR.Checked = false;
            cbL.Checked = false;
            cbBSlsh.CheckState = CheckState.Unchecked;
            cbEql.CheckState = CheckState.Unchecked;
            cbFSlsh.CheckState = CheckState.Unchecked;
            cbCaps.CheckState = CheckState.Unchecked;
            cbA.Checked = false;
            cbO.Checked = false;
            cbE.Checked = false;
            cbU.Checked = false;
            cbI.Checked = false;
            cbD.Checked = false;
            cbH.Checked = false;
            cbT.Checked = false;
            cbN.Checked = false;
            cbS.Checked = false;
            cbDash.CheckState = CheckState.Unchecked;
            cbEntr.Checked = false;
            cbLShft.Checked = false;
            cbColon.CheckState = CheckState.Unchecked;
            cbQ.Checked = false;
            cbJ.Checked = false;
            cbK.Checked = false;
            cbX.Checked = false;
            cbB.Checked = false;
            cbM.Checked = false;
            cbW.Checked = false;
            cbV.Checked = false;
            cbZ.Checked = false;
            cbRShft.Checked = false;
            cbLCtrl.Checked = false;
            cbRCtrl.Checked = false;
        }

        private void keysAll()      // check all checkbuttons for edge case where user selects nothing
        {         
            cbEsc.Checked = true;
            cbF1.Checked = true;
            cbF2.Checked = true;
            cbF3.Checked = true;
            cbF4.Checked = true;
            cbF5.Checked = true;
            cbF6.Checked = true;
            cbF7.Checked = true;
            cbF8.Checked = true;
            cbF9.Checked = true;
            cbF10.Checked = true;
            cbF11.Checked = true;
            cbF12.Checked = true;
            cbTilda.CheckState = CheckState.Indeterminate;
            cb1.CheckState = CheckState.Indeterminate;
            cb2.CheckState = CheckState.Indeterminate;
            cb3.CheckState = CheckState.Indeterminate;
            cb4.CheckState = CheckState.Indeterminate;
            cb5.CheckState = CheckState.Indeterminate;
            cb6.CheckState = CheckState.Indeterminate;
            cb7.CheckState = CheckState.Indeterminate;
            cb8.CheckState = CheckState.Indeterminate;
            cb9.CheckState = CheckState.Indeterminate;
            cb0.CheckState = CheckState.Indeterminate;
            cbLSqr.CheckState = CheckState.Indeterminate;
            cbRSqr.CheckState = CheckState.Indeterminate;
            cbBack.Checked = true;
            cbLTab.Checked = true;
            cbQte.CheckState = CheckState.Indeterminate;
            cbComma.CheckState = CheckState.Indeterminate;
            cbPrd.CheckState = CheckState.Indeterminate;
            cbP.Checked = true;
            cbY.Checked = true;
            cbF.Checked = true;
            cbG.Checked = true;
            cbC.Checked = true;
            cbR.Checked = true;
            cbL.Checked = true;
            cbBSlsh.CheckState = CheckState.Indeterminate;
            cbEql.CheckState = CheckState.Indeterminate;
            cbFSlsh.CheckState = CheckState.Indeterminate;
            cbCaps.CheckState = CheckState.Indeterminate;
            cbA.Checked = true;
            cbO.Checked = true;
            cbE.Checked = true;
            cbU.Checked = true;
            cbI.Checked = true;
            cbD.Checked = true;
            cbH.Checked = true;
            cbT.Checked = true;
            cbN.Checked = true;
            cbS.Checked = true;
            cbDash.CheckState = CheckState.Indeterminate;
            cbEntr.Checked = true;
            cbLShft.Checked = true;
            cbColon.CheckState = CheckState.Indeterminate;
            cbQ.Checked = true;
            cbJ.Checked = true;
            cbK.Checked = true;
            cbX.Checked = true;
            cbB.Checked = true;
            cbM.Checked = true;
            cbW.Checked = true;
            cbV.Checked = true;
            cbZ.Checked = true;
            cbRShft.Checked = true;
            cbLCtrl.Checked = true;
            cbRCtrl.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sessionTimer.TimerCount--;
            lblTimerDisplay.Text = (sessionTimer.TimerCount / 10).ToString();

            if (sessionTimer.TimerCount == 0)
            {
                timer1.Stop();
                lblMain.Text = "Time";
                disableKeyBoard = true;

            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)  // allows points added or subtracted to fade away
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
                lblPointsDisplay.ForeColor = Color.FromArgb(pointFade.R, pointFade.G, pointFade.B); ;
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

        private void cbFingerings_CheckedChanged(object sender, EventArgs e)  // toggle viewing correct key fingerings
        {
            Fingerings one = new Fingerings(255, 255, 131, 62);         // thumb
            Fingerings two = new Fingerings(255, 132, 138, 224);         // pointer
            Fingerings three = new Fingerings(255, 149, 73, 203);       // middle
            Fingerings four = new Fingerings(255, 160, 192, 76);        // ring
            Fingerings five = new Fingerings(255, 0, 153, 217);        // pinky

            if (cbFingerings.Checked)
            {
                cbEsc.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbF1.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbF2.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbF3.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbF4.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbF5.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbF6.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbF7.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbF8.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbF9.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbF10.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbF11.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbF12.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbTilda.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cb1.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cb2.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cb3.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cb4.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cb5.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cb6.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cb7.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cb8.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cb9.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cb0.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbLSqr.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbRSqr.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbBack.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbLTab.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbQte.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbComma.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbPrd.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbP.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbY.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbF.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbG.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbC.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbR.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbL.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbBSlsh.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbEql.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbFSlsh.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbCaps.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbA.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbO.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbE.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbU.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbI.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbD.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbH.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbT.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbN.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbS.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbDash.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbEntr.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbLShft.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbColon.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbQ.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbJ.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbK.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbX.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbB.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbM.BackColor = Color.FromArgb(two.O, two.R, two.G, two.B);
                cbW.BackColor = Color.FromArgb(three.O, three.R, three.G, three.B);
                cbV.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbZ.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbRShft.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbLCtrl.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbStrt.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);
                cbLAlt.BackColor = Color.FromArgb(one.O, one.R, one.G, one.B);
                cbSpace.BackColor = Color.FromArgb(one.O, one.R, one.G, one.B);
                cbRAlt.BackColor = Color.FromArgb(one.O, one.R, one.G, one.B);
                cbMenu.BackColor = Color.FromArgb(four.O, four.R, four.G, four.B);
                cbRCtrl.BackColor = Color.FromArgb(five.O, five.R, five.G, five.B);

            }
            else
            {
                cbEsc.BackColor = default(Color);
                cbEsc.UseVisualStyleBackColor = true;
                cbF1.BackColor = default(Color);
                cbF1.UseVisualStyleBackColor = true;
                cbF2.BackColor = default(Color);
                cbF2.UseVisualStyleBackColor = true;
                cbF3.BackColor = default(Color);
                cbF3.UseVisualStyleBackColor = true;
                cbF4.BackColor = default(Color);
                cbF4.UseVisualStyleBackColor = true;
                cbF5.BackColor = default(Color);
                cbF5.UseVisualStyleBackColor = true;
                cbF6.BackColor = default(Color);
                cbF6.UseVisualStyleBackColor = true;
                cbF7.BackColor = default(Color);
                cbF7.UseVisualStyleBackColor = true;
                cbF8.BackColor = default(Color);
                cbF8.UseVisualStyleBackColor = true;
                cbF9.BackColor = default(Color);
                cbF9.UseVisualStyleBackColor = true;
                cbF10.BackColor = default(Color);
                cbF10.UseVisualStyleBackColor = true;
                cbF11.BackColor = default(Color);
                cbF11.UseVisualStyleBackColor = true;
                cbF12.BackColor = default(Color);
                cbF12.UseVisualStyleBackColor = true;
                cbTilda.BackColor = default(Color);
                cbTilda.UseVisualStyleBackColor = true;
                cb1.BackColor = default(Color);
                cb1.UseVisualStyleBackColor = true;
                cb2.BackColor = default(Color);
                cb2.UseVisualStyleBackColor = true;
                cb3.BackColor = default(Color);
                cb3.UseVisualStyleBackColor = true;
                cb4.BackColor = default(Color);
                cb4.UseVisualStyleBackColor = true;
                cb5.BackColor = default(Color);
                cb5.UseVisualStyleBackColor = true;
                cb6.BackColor = default(Color);
                cb6.UseVisualStyleBackColor = true;
                cb7.BackColor = default(Color);
                cb7.UseVisualStyleBackColor = true;
                cb8.BackColor = default(Color);
                cb8.UseVisualStyleBackColor = true;
                cb9.BackColor = default(Color);
                cb9.UseVisualStyleBackColor = true;
                cb0.BackColor = default(Color);
                cb0.UseVisualStyleBackColor = true;
                cbLSqr.BackColor = default(Color);
                cbLSqr.UseVisualStyleBackColor = true;
                cbRSqr.BackColor = default(Color);
                cbRSqr.UseVisualStyleBackColor = true;
                cbBack.BackColor = default(Color);
                cbBack.UseVisualStyleBackColor = true;
                cbLTab.BackColor = default(Color);
                cbLTab.UseVisualStyleBackColor = true;
                cbQte.BackColor = default(Color);
                cbQte.UseVisualStyleBackColor = true;
                cbComma.BackColor = default(Color);
                cbComma.UseVisualStyleBackColor = true;
                cbPrd.BackColor = default(Color);
                cbPrd.UseVisualStyleBackColor = true;
                cbP.BackColor = default(Color);
                cbP.UseVisualStyleBackColor = true;
                cbY.BackColor = default(Color);
                cbY.UseVisualStyleBackColor = true;
                cbF.BackColor = default(Color);
                cbF.UseVisualStyleBackColor = true;
                cbG.BackColor = default(Color);
                cbG.UseVisualStyleBackColor = true;
                cbC.BackColor = default(Color);
                cbC.UseVisualStyleBackColor = true;
                cbR.BackColor = default(Color);
                cbR.UseVisualStyleBackColor = true;
                cbL.BackColor = default(Color);
                cbL.UseVisualStyleBackColor = true;
                cbBSlsh.BackColor = default(Color);
                cbBSlsh.UseVisualStyleBackColor = true;
                cbEql.BackColor = default(Color);
                cbEql.UseVisualStyleBackColor = true;
                cbFSlsh.BackColor = default(Color);
                cbFSlsh.UseVisualStyleBackColor = true;
                cbCaps.BackColor = default(Color);
                cbCaps.UseVisualStyleBackColor = true;
                cbA.BackColor = default(Color);
                cbA.UseVisualStyleBackColor = true;
                cbO.BackColor = default(Color);
                cbO.UseVisualStyleBackColor = true;
                cbE.BackColor = default(Color);
                cbE.UseVisualStyleBackColor = true;
                cbU.BackColor = default(Color);
                cbU.UseVisualStyleBackColor = true;
                cbI.BackColor = default(Color);
                cbI.UseVisualStyleBackColor = true;
                cbD.BackColor = default(Color);
                cbD.UseVisualStyleBackColor = true;
                cbH.BackColor = default(Color);
                cbH.UseVisualStyleBackColor = true;
                cbT.BackColor = default(Color);
                cbT.UseVisualStyleBackColor = true;
                cbN.BackColor = default(Color);
                cbN.UseVisualStyleBackColor = true;
                cbS.BackColor = default(Color);
                cbS.UseVisualStyleBackColor = true;
                cbDash.BackColor = default(Color);
                cbDash.UseVisualStyleBackColor = true;
                cbEntr.BackColor = default(Color);
                cbEntr.UseVisualStyleBackColor = true;
                cbLShft.BackColor = default(Color);
                cbLShft.UseVisualStyleBackColor = true;
                cbColon.BackColor = default(Color);
                cbColon.UseVisualStyleBackColor = true;
                cbQ.BackColor = default(Color);
                cbQ.UseVisualStyleBackColor = true;
                cbJ.BackColor = default(Color);
                cbJ.UseVisualStyleBackColor = true;
                cbK.BackColor = default(Color);
                cbK.UseVisualStyleBackColor = true;
                cbX.BackColor = default(Color);
                cbX.UseVisualStyleBackColor = true;
                cbB.BackColor = default(Color);
                cbB.UseVisualStyleBackColor = true;
                cbM.BackColor = default(Color);
                cbM.UseVisualStyleBackColor = true;
                cbW.BackColor = default(Color);
                cbW.UseVisualStyleBackColor = true;
                cbV.BackColor = default(Color);
                cbV.UseVisualStyleBackColor = true;
                cbZ.BackColor = default(Color);
                cbZ.UseVisualStyleBackColor = true;
                cbRShft.BackColor = default(Color);
                cbRShft.UseVisualStyleBackColor = true;
                cbLCtrl.BackColor = default(Color);
                cbLCtrl.UseVisualStyleBackColor = true;
                cbStrt.BackColor = default(Color);
                cbStrt.UseVisualStyleBackColor = true;
                cbLAlt.BackColor = default(Color);
                cbLAlt.UseVisualStyleBackColor = true;
                cbSpace.BackColor = default(Color);
                cbSpace.UseVisualStyleBackColor = true;
                cbRAlt.BackColor = default(Color);
                cbRAlt.UseVisualStyleBackColor = true;
                cbMenu.BackColor = default(Color);
                cbMenu.UseVisualStyleBackColor = true;
                cbRCtrl.BackColor = default(Color);
                cbRCtrl.UseVisualStyleBackColor = true;
              
            }
        }
    }
}
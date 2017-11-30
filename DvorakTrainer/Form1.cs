using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DvorakTrainer;

namespace Dvorak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private KeyRandomizer userKeyListObject;  
        private int correct = 0;                  // temp score keeper
        private int actual = 0;                   // temp score keeper

        public void btnPractice_Click(object sender, EventArgs e)
        {
            userKeyListObject = new KeyRandomizer(putUserSelectedKeysIntoList());
            getRandomKeyAndDisplay();

            // clear statistics - call to statitics class
            // clear timer      - call to timer class
            // start timer       - call to timer class
            // clear list of keys   - call to KeyRandomizer class
            // return list of selected keys - call to model
            // randomize keys  - call to KeyRandomizer class
            // display random key in label - call to model
            // clear label with correct button push  - call to model
            // randomize key - call to KeyRandomizer class      
            // when timer ends, game over 
        }

        private List<int> putUserSelectedKeysIntoList()     // Return a list of all selected keys 
        {
            List<int> mySelectedKeys = new List<int>();

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

            return mySelectedKeys;
        }

        private void getRandomKeyAndDisplay() //Gets random key from list and displays
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
                case 54: lblMain.Text = "Shft"; break;
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
                case 65: lblMain.Text = "Shft"; break;
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
                case 88: lblMain.Text = "<"; break;
                case 89: lblMain.Text = "?"; break;
                case 90: lblMain.Text = "+"; break;
                case 91: lblMain.Text = "|"; break;
                case 92: lblMain.Text = "_"; break;
                case 93: lblMain.Text = ":"; break;

            }
        }
        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {// if selected key matches user inputs

            if (!e.Shift)      // if shift NOT present, these key combos work
            {
                if ((e.KeyCode == Keys.Escape) && (userKeyListObject.CurrentRandomKey == 0)) { correct++; getRandomKeyAndDisplay(); }          // if key press correct, add point and go again
                else if ((e.KeyCode == Keys.F1) && (userKeyListObject.CurrentRandomKey == 1)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F2) && (userKeyListObject.CurrentRandomKey == 2)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F3) && (userKeyListObject.CurrentRandomKey == 3)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F4) && (userKeyListObject.CurrentRandomKey == 4)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F5) && (userKeyListObject.CurrentRandomKey == 5)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F6) && (userKeyListObject.CurrentRandomKey == 6)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F7) && (userKeyListObject.CurrentRandomKey == 7)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F8) && (userKeyListObject.CurrentRandomKey == 8)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F9) && (userKeyListObject.CurrentRandomKey == 9)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F10) && (userKeyListObject.CurrentRandomKey == 10)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F11) && (userKeyListObject.CurrentRandomKey == 11)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F12) && (userKeyListObject.CurrentRandomKey == 12)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Oemtilde) && (userKeyListObject.CurrentRandomKey == 13)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D1) && (userKeyListObject.CurrentRandomKey == 14)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D2) && (userKeyListObject.CurrentRandomKey == 15)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D3) && (userKeyListObject.CurrentRandomKey == 16)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D4) && (userKeyListObject.CurrentRandomKey == 17)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D5) && (userKeyListObject.CurrentRandomKey == 18)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D6) && (userKeyListObject.CurrentRandomKey == 19)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D7) && (userKeyListObject.CurrentRandomKey == 20)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D8) && (userKeyListObject.CurrentRandomKey == 21)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D9) && (userKeyListObject.CurrentRandomKey == 22)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D0) && (userKeyListObject.CurrentRandomKey == 23)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemOpenBrackets) && (userKeyListObject.CurrentRandomKey == 24)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemCloseBrackets) && (userKeyListObject.CurrentRandomKey == 25)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Back) && (userKeyListObject.CurrentRandomKey == 26)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Tab) && (userKeyListObject.CurrentRandomKey == 27)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemQuotes) && (userKeyListObject.CurrentRandomKey == 28)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Oemcomma) && (userKeyListObject.CurrentRandomKey == 29)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemPeriod) && (userKeyListObject.CurrentRandomKey == 30)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.P) && (userKeyListObject.CurrentRandomKey == 31)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Y) && (userKeyListObject.CurrentRandomKey == 32)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.F) && (userKeyListObject.CurrentRandomKey == 33)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.G) && (userKeyListObject.CurrentRandomKey == 34)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.C) && (userKeyListObject.CurrentRandomKey == 35)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.R) && (userKeyListObject.CurrentRandomKey == 36)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.L) && (userKeyListObject.CurrentRandomKey == 37)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemQuestion) && (userKeyListObject.CurrentRandomKey == 38)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Oemplus) && (userKeyListObject.CurrentRandomKey == 39)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemPipe) && (userKeyListObject.CurrentRandomKey == 40)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.CapsLock) && (userKeyListObject.CurrentRandomKey == 41)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.A) && (userKeyListObject.CurrentRandomKey == 42)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.O) && (userKeyListObject.CurrentRandomKey == 43)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.E) && (userKeyListObject.CurrentRandomKey == 44)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.U) && (userKeyListObject.CurrentRandomKey == 45)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.I) && (userKeyListObject.CurrentRandomKey == 46)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D) && (userKeyListObject.CurrentRandomKey == 47)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.H) && (userKeyListObject.CurrentRandomKey == 48)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.T) && (userKeyListObject.CurrentRandomKey == 49)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.N) && (userKeyListObject.CurrentRandomKey == 50)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.S) && (userKeyListObject.CurrentRandomKey == 51)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemMinus) && (userKeyListObject.CurrentRandomKey == 52)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Enter) && (userKeyListObject.CurrentRandomKey == 53)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.ShiftKey) && (userKeyListObject.CurrentRandomKey == 54)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemSemicolon) && (userKeyListObject.CurrentRandomKey == 55)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Q) && (userKeyListObject.CurrentRandomKey == 56)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.J) && (userKeyListObject.CurrentRandomKey == 57)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.K) && (userKeyListObject.CurrentRandomKey == 58)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.X) && (userKeyListObject.CurrentRandomKey == 59)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.B) && (userKeyListObject.CurrentRandomKey == 60)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.M) && (userKeyListObject.CurrentRandomKey == 61)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.W) && (userKeyListObject.CurrentRandomKey == 62)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.V) && (userKeyListObject.CurrentRandomKey == 63)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Z) && (userKeyListObject.CurrentRandomKey == 64)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.ShiftKey) && (userKeyListObject.CurrentRandomKey == 65)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.ControlKey) && (userKeyListObject.CurrentRandomKey == 66)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Menu) && (userKeyListObject.CurrentRandomKey == 67)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Alt) && (userKeyListObject.CurrentRandomKey == 68)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Space) && (userKeyListObject.CurrentRandomKey == 69)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Alt) && (userKeyListObject.CurrentRandomKey == 70)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Menu) && (userKeyListObject.CurrentRandomKey == 71)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.ControlKey) && (userKeyListObject.CurrentRandomKey == 72)) { correct++; getRandomKeyAndDisplay(); }
            }

            else     // if shift required, these key combos work
            {
                if ((e.KeyCode == Keys.Oemtilde && e.Shift) && (userKeyListObject.CurrentRandomKey == 73)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D1 && e.Shift) && (userKeyListObject.CurrentRandomKey == 74)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D2 && e.Shift) && (userKeyListObject.CurrentRandomKey == 75)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D3 && e.Shift) && (userKeyListObject.CurrentRandomKey == 76)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D4 && e.Shift) && (userKeyListObject.CurrentRandomKey == 77)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D5 && e.Shift) && (userKeyListObject.CurrentRandomKey == 78)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D6 && e.Shift) && (userKeyListObject.CurrentRandomKey == 79)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D7 && e.Shift) && (userKeyListObject.CurrentRandomKey == 80)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D8 && e.Shift) && (userKeyListObject.CurrentRandomKey == 81)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D9 && e.Shift) && (userKeyListObject.CurrentRandomKey == 82)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.D0 && e.Shift) && (userKeyListObject.CurrentRandomKey == 83)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemOpenBrackets && e.Shift) && (userKeyListObject.CurrentRandomKey == 84)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemCloseBrackets && e.Shift) && (userKeyListObject.CurrentRandomKey == 85)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemQuotes && e.Shift) && (userKeyListObject.CurrentRandomKey == 86)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Oemcomma && e.Shift) && (userKeyListObject.CurrentRandomKey == 87)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemPeriod && e.Shift) && (userKeyListObject.CurrentRandomKey == 88)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemQuestion && e.Shift) && (userKeyListObject.CurrentRandomKey == 89)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.Oemplus && e.Shift) && (userKeyListObject.CurrentRandomKey == 90)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemPipe && e.Shift) && (userKeyListObject.CurrentRandomKey == 91)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemMinus && e.Shift) && (userKeyListObject.CurrentRandomKey == 92)) { correct++; getRandomKeyAndDisplay(); }
                else if ((e.KeyCode == Keys.OemSemicolon && e.Shift) && (userKeyListObject.CurrentRandomKey == 93)) { correct++; getRandomKeyAndDisplay(); }

                else if ((e.KeyCode == Keys.Back && e.Shift) && (userKeyListObject.CurrentRandomKey == 1000))  
                {// this hotkey combo (Shift + Backspace) same as "pressing Practice button"

                    //timerClear();
                    //statisticsClear();
                    //timer1.Start();
                    //getRandomKeyAndDisplay();
                }
            }

            //if (!e.Shift)       // For scorekeeping to ensure that key and key+shift are exclusive
            //{                   // if any key pressed, add point to total and display


            //    if (e.KeyCode == Keys.Escape) { total++; counters(); }   
            //    else if (e.KeyCode == Keys.F1) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F2) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F3) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F4) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F5) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F6) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F7) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F8) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F9) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F10) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F11) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F12) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Oemtilde) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D1) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D2) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D3) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D4) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D5) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D6) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D7) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D8) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D9) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D0) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemOpenBrackets) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemCloseBrackets) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Back) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Tab) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemQuotes) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Oemcomma) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemPeriod) { total++; counters(); }
            //    else if (e.KeyCode == Keys.P) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Y) { total++; counters(); }
            //    else if (e.KeyCode == Keys.F) { total++; counters(); }
            //    else if (e.KeyCode == Keys.G) { total++; counters(); }
            //    else if (e.KeyCode == Keys.C) { total++; counters(); }
            //    else if (e.KeyCode == Keys.R) { total++; counters(); }
            //    else if (e.KeyCode == Keys.L) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemQuestion) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Oemplus) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemPipe) { total++; counters(); }
            //    else if (e.KeyCode == Keys.CapsLock) { total++; counters(); }
            //    else if (e.KeyCode == Keys.A) { total++; counters(); }
            //    else if (e.KeyCode == Keys.O) { total++; counters(); }
            //    else if (e.KeyCode == Keys.E) { total++; counters(); }
            //    else if (e.KeyCode == Keys.U) { total++; counters(); }
            //    else if (e.KeyCode == Keys.I) { total++; counters(); }
            //    else if (e.KeyCode == Keys.D) { total++; counters(); }
            //    else if (e.KeyCode == Keys.H) { total++; counters(); }
            //    else if (e.KeyCode == Keys.T) { total++; counters(); }
            //    else if (e.KeyCode == Keys.N) { total++; counters(); }
            //    else if (e.KeyCode == Keys.S) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemMinus) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Enter) { total++; counters(); }
            //    else if (e.KeyCode == Keys.ShiftKey) { total++; counters(); }
            //    else if (e.KeyCode == Keys.OemSemicolon) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Q) { total++; counters(); }
            //    else if (e.KeyCode == Keys.J) { total++; counters(); }
            //    else if (e.KeyCode == Keys.K) { total++; counters(); }
            //    else if (e.KeyCode == Keys.X) { total++; counters(); }
            //    else if (e.KeyCode == Keys.B) { total++; counters(); }
            //    else if (e.KeyCode == Keys.M) { total++; counters(); }
            //    else if (e.KeyCode == Keys.W) { total++; counters(); }
            //    else if (e.KeyCode == Keys.V) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Z) { total++; counters(); }
            //    else if (e.KeyCode == Keys.ShiftKey) { total++; counters(); }
            //    else if (e.KeyCode == Keys.ControlKey) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Menu) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Space) { total++; counters(); }
            //    else if (e.Alt) { total++; counters(); }
            //    else if (e.KeyCode == Keys.Menu) { total++; counters(); }
            //}

            //else
            //{   // if key pressed with shift, outside of if


            //    if (e.KeyCode == Keys.Oemtilde && e.Shift) { total++; counters(); }     
            //    if (e.KeyCode == Keys.D1 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D2 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D3 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D4 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D5 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D6 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D7 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D8 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D9 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.D0 && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemOpenBrackets && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemCloseBrackets && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemQuestion && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.Oemplus && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemPipe && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemMinus && e.Shift) { total++; counters(); }
            //    if (e.KeyCode == Keys.OemSemicolon && e.Shift) { total++; counters(); }

            //}

            //  else if (e.KeyCode == Keys.ShiftKey) { total++; counters(); }



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


    }
}

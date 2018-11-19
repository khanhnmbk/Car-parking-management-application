﻿using QuanLyBaiXe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyBaiXe.Resource.FeeEditPanel
{
    public class FeeEditPanelViewModel : BaseViewModel
    {
        private string _Fee;
        public string Fee { get=>_Fee; set { _Fee = value;OnPropertyChanged(); } }

        #region COMMAND
        public ICommand MoveCommand { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand CheckChangedCommand { get; set; }
        #endregion

        private string _posID;
        public string posID { get => _posID; set { _posID = value; OnPropertyChanged(); } }

        public FeeEditPanelViewModel()
        {
            MoveCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Window a = p as Window; a.DragMove(); });
            AcceptCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Accept(p as Window); });
            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Window a = p as Window; a.Close(); });
            CheckChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CheckBox a = p as CheckBox; CheckFee(a); });
        }

        void Accept(Window a)
        {
            //int posid = int.Parse(posID);
            // var b = DataProvider.Ins.Data.CarParkingLayouts.Where(p => p.BlockID == MainViewModel.currentBlockID && p.BuildingID == MainViewModel.currentBuildingID && p.ID == posid).FirstOrDefault();
            // b.StatusID = 1;
            // DataProvider.Ins.Data.SaveChanges();
            a.Close();
        }

        void CheckFee(CheckBox a)
        {
            double fee;
            if (string.IsNullOrWhiteSpace(Fee) || !double.TryParse(Fee, out fee))
            {
                FeeMessageBox panel = new FeeMessageBox();
                var point = a.PointToScreen(Mouse.GetPosition(a));
                panel.Left = point.X - panel.Width;
                panel.Top = point.Y;
                panel.ShowDialog();
                a.IsChecked = false;
            }
            
        }
    }
}
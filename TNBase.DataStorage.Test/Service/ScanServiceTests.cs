﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TNBase.Objects;

namespace TNBase.DataStorage.Test.Services
{
    [TestClass]
    public class ScanServiceTests
    {
        [TestMethod]
        public void AddScans_ShouldAddScansToDatabase()
        {
            var scans = new List<Scan> {
                    new Scan { Wallet = 1 },
                    new Scan { Wallet = 1 }
                };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            Assert.AreEqual(2, context.Scans.Count());
        }

        [TestMethod]
        public void AddScans_ShouldMapValuesCorrectly()
        {
            var scans = new List<Scan> {
                    new Scan {
                        Wallet = 1,
                        ScanType = ScanTypes.IN,
                        WalletType = WalletTypes.News
                    },
                    new Scan {
                        Wallet = 2,
                        ScanType = ScanTypes.OUT,
                        WalletType = WalletTypes.Magazine
                    }
                };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test1",
                Surname = "Tester",
                InOutRecords = new InOutRecords()
            });

            context.Listeners.Add(new Listener
            {
                Forename = "Test2",
                Surname = "Tester",
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            var storedScans = context.Scans.ToList();

            Assert.AreEqual(1, storedScans.ElementAt(0).Wallet);
            Assert.AreEqual(ScanTypes.IN, storedScans.ElementAt(0).ScanType);
            Assert.AreEqual(WalletTypes.News, storedScans.ElementAt(0).WalletType);
            Assert.AreEqual(2, storedScans.ElementAt(1).Wallet);
            Assert.AreEqual(ScanTypes.OUT, storedScans.ElementAt(1).ScanType);
            Assert.AreEqual(WalletTypes.Magazine, storedScans.ElementAt(1).WalletType);
        }

        [TestMethod]
        public void AddScans_ShouldSetCurrentDate()
        {
            var scans = new List<Scan> {
                new Scan { Wallet = 1 }
            };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                Stock = 1,
                MagazineStock = 2,
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            var before = DateTime.UtcNow;
            service.AddScans(scans);
            var after = DateTime.UtcNow;

            var storedScan = context.Scans.First();
            Assert.IsTrue(before <= storedScan.Recorded, "Date is greater or equal to before");
            Assert.IsTrue(after >= storedScan.Recorded, "Date is less or equal to after");
        }

        [TestMethod]
        public void AddScans_ShouldIncrementNewsStock_WhenNewsScanInAdded()
        {
            var scans = new List<Scan> {
                new Scan {
                    Wallet = 1,
                    ScanType = ScanTypes.IN,
                    WalletType = WalletTypes.News
                }
            };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                Stock = 1,
                MagazineStock = 2,
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            var listener = context.Listeners.FirstOrDefault();
            Assert.AreEqual(2, listener.Stock);
            Assert.AreEqual(2, listener.MagazineStock);
        }

        [TestMethod]
        public void AddScans_ShouldIncrementMagazineStock_WhenMagazineScanInAdded()
        {
            var scans = new List<Scan> {
                new Scan {
                    Wallet = 1,
                    ScanType = ScanTypes.IN,
                    WalletType = WalletTypes.Magazine
                }
            };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                Stock = 1,
                MagazineStock = 2,
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            var listener = context.Listeners.FirstOrDefault();
            Assert.AreEqual(1, listener.Stock);
            Assert.AreEqual(3, listener.MagazineStock);
        }

        [TestMethod]
        public void AddScans_ShouldDecrementNewsStock_WhenNewsScanOutAdded()
        {
            var scans = new List<Scan> {
                new Scan {
                    Wallet = 1,
                    ScanType = ScanTypes.OUT,
                    WalletType = WalletTypes.News
                }
            };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                Stock = 1,
                MagazineStock = 2,
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            var listener = context.Listeners.FirstOrDefault();
            Assert.AreEqual(0, listener.Stock);
            Assert.AreEqual(2, listener.MagazineStock);
        }

        [TestMethod]
        public void AddScans_ShouldDecrementMagazineStock_WhenMagazineScanOutAdded()
        {
            var scans = new List<Scan> {
                new Scan {
                    Wallet = 1,
                    ScanType = ScanTypes.OUT,
                    WalletType = WalletTypes.Magazine
                }
            };

            using var context = new Repository.TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            context.Listeners.Add(new Listener
            {
                Forename = "Test",
                Surname = "Tester",
                Stock = 1,
                MagazineStock = 2,
                InOutRecords = new InOutRecords()
            });
            context.SaveChanges();

            var service = new ScanService(context);

            service.AddScans(scans);

            var listener = context.Listeners.FirstOrDefault();
            Assert.AreEqual(1, listener.Stock);
            Assert.AreEqual(1, listener.MagazineStock);
        }
    }
}

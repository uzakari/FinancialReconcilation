using Reconcilation.Management.Application.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Reconcilation.Management.Infrastructure.Helpers;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;

namespace FInacialReconcilation.Management.FunctionalTest.Functions
{
    public class TransactionReconcilationTests
    {

        [Fact]
        public void MatchingRecordTest()
        {

            // act, arrange, assert
            var firstFileContent = new List<FileFormat>()
            {
                new FileFormat{
                    Id= 2,
                    ProfileName="Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                    TransactionAmount= -20000,
                    TransactionNarrative= " * MOLEPS ATM25 MOLEPOLOLE    BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011808649511,
                    TransactionType= 1,
                    WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },

                new FileFormat
                {
                        Id= 7,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                        TransactionAmount= -25000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384012122267350,
                        TransactionType= 1,
                        WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                },

                new FileFormat
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },

                new FileFormat
                {
                     
                    Id= 5,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 464011802918801,
                    TransactionType= 1,
                    WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"
  
               },

                new FileFormat
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTime.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },

                new FileFormat
                {
                    
                    Id= 3,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011815513406,
                    TransactionType= 1,
                    WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                }

            };

            var secondFileContent = new List<FileFormat>()
            {
                new FileFormat()
                {
                        Id= 2,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                        TransactionAmount= -20000,
                        TransactionNarrative= "*MOLEPS ATM25             MOLEPOLOLE    BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011808649511,
                        TransactionType= 1,
                        WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },
                new FileFormat()
                {
                        Id= 3,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011815513406,
                        TransactionType= 1,
                        WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                },
                new FileFormat()
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },
                new FileFormat()
                {
                        Id= 5,
                        ProfileName= "Card Campaign",
                        TransactionDate=DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011802918801,
                        TransactionType= 1,
                        WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"
                },
                new FileFormat()
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },
                new FileFormat()
                {
                    Id = 7,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                    TransactionAmount= -25000,
                    TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 384012122267350,
                    TransactionType=1,
                    WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                }
            };

            var matchingContentFirstFile = FileHelper.MatchedRecords(firstFileContent, secondFileContent).Select(a => (a.firstFile));

            var matchingContentSecondFile = FileHelper.MatchedRecords(firstFileContent, secondFileContent).Select(a => (a.firstFile));

            Assert.NotNull(matchingContentSecondFile);

            Assert.NotNull(matchingContentSecondFile);

            Assert.Equal(matchingContentFirstFile, matchingContentSecondFile);

        }

        [Fact]
        public void UnmatchRecordTest()
        {
            var firstFileContent = new List<FileFormat>()
            {
                new FileFormat{
                    Id= 2,
                    ProfileName="Umar Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                    TransactionAmount= -20000,
                    TransactionNarrative= " * MOLEPS ATM25 MOLEPOLOLE    BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011808649511,
                    TransactionType= 1,
                    WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },

                new FileFormat
                {
                        Id= 7,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                        TransactionAmount= -25000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384012122267350,
                        TransactionType= 1,
                        WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                },

                new FileFormat
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },

                new FileFormat
                {

                    Id= 5,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 464011802918801,
                    TransactionType= 1,
                    WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"

               },

                new FileFormat
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTime.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },

                new FileFormat
                {

                    Id= 3,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011815513406,
                    TransactionType= 1,
                    WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                }

            };

            var secondFileContent = new List<FileFormat>()
            {
                new FileFormat()
                {
                        Id= 2,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                        TransactionAmount= -20000,
                        TransactionNarrative= "*MOLEPS ATM25             MOLEPOLOLE    BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011808649511,
                        TransactionType= 1,
                        WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },
                new FileFormat()
                {
                        Id= 3,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011815513406,
                        TransactionType= 1,
                        WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                },
                new FileFormat()
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },
                new FileFormat()
                {
                        Id= 5,
                        ProfileName= "Card Campaign",
                        TransactionDate=DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011802918801,
                        TransactionType= 1,
                        WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"
                },
                new FileFormat()
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },
                new FileFormat()
                {
                    Id = 7,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                    TransactionAmount= -25000,
                    TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 384012122267350,
                    TransactionType=1,
                    WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                }
            };

            var unmatchRecord = firstFileContent.Except(secondFileContent, new FileComparer());

            Assert.Single(unmatchRecord);


        }

        [Fact]
        public void GetUmatchRecordTest()
        {
            var firstFileContent = new List<FileFormat>()
            {
                new FileFormat{
                    Id= 2,
                    ProfileName="Umar Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                    TransactionAmount= -20000,
                    TransactionNarrative= " * MOLEPS ATM25 MOLEPOLOLE    BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011808649511,
                    TransactionType= 1,
                    WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },

                new FileFormat
                {
                        Id= 7,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                        TransactionAmount= -25000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384012122267350,
                        TransactionType= 1,
                        WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                },

                new FileFormat
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },

                new FileFormat
                {

                    Id= 5,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 464011802918801,
                    TransactionType= 1,
                    WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"

               },

                new FileFormat
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTime.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },

                new FileFormat
                {

                    Id= 3,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                    TransactionAmount= -10000,
                    TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 584011815513406,
                    TransactionType= 1,
                    WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                }

            };

            var secondFileContent = new List<FileFormat>()
            {
                new FileFormat()
                {
                        Id= 2,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:27:44+01:00").Date,
                        TransactionAmount= -20000,
                        TransactionNarrative= "*MOLEPS ATM25             MOLEPOLOLE    BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011808649511,
                        TransactionType= 1,
                        WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                },
                new FileFormat()
                {
                        Id= 3,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T22:39:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "*MOGODITSHANE2            MOGODITHSANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 584011815513406,
                        TransactionType= 1,
                        WalletReference= "P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5"
                },
                new FileFormat()
                {
                        Id= 4,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-11T23:28:11+01:00").Date,
                        TransactionAmount= -5000,
                        TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011844938429,
                        TransactionType= 1,
                        WalletReference= "P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy"
                },
                new FileFormat()
                {
                        Id= 5,
                        ProfileName= "Card Campaign",
                        TransactionDate=DateTimeOffset.Parse("2014-01-12T02:18:11+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "PALAPYE BRANCH ATM        PALAPYE       BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 464011802918801,
                        TransactionType= 1,
                        WalletReference= "P_NzI5OTQ5NDRfMTM4NDE2MjA2Ny45NjUy"
                },
                new FileFormat()
                {
                        Id= 6,
                        ProfileName= "Card Campaign",
                        TransactionDate= DateTimeOffset.Parse("2014-01-12T03:10:45+01:00").Date,
                        TransactionAmount= -10000,
                        TransactionNarrative= "ENGEN MOGODITSHANE AT     BOTSWANA      BW",
                        TransactionDescription= "DEDUCT",
                        TransactionId= 384011834441723,
                        TransactionType= 1,
                        WalletReference= "P_NzI4NDA3ODRfMTM4NTk5MDA2NS4xNDQ="
                },
                new FileFormat()
                {
                    Id = 7,
                    ProfileName= "Card Campaign",
                    TransactionDate= DateTimeOffset.Parse("2014-01-12T03:23:42+01:00").Date,
                    TransactionAmount= -25000,
                    TransactionNarrative= "CAPITAL BANK              MOGODITSHANE  BW",
                    TransactionDescription= "DEDUCT",
                    TransactionId= 384012122267350,
                    TransactionType=1,
                    WalletReference= "P_NzIyNTY4NzNfMTM4NjY3ODk2MC4wNzcx"
                }
            };

            var unmatchRecord = firstFileContent.Except(secondFileContent, new FileComparer());

            var unmatchRecordsContents = FileHelper.GetUnmatchRecord(unmatchRecord, "TestData");

            Assert.IsType<UnmatchFileResultVm>(unmatchRecordsContents);

            Assert.Single(unmatchRecord);
        }
    }
}

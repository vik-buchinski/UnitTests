using System;
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

        // unit test code
        [TestMethod]
        public void Credit_Balance()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Credit(creditAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not credited correctly");
        }

        // unit test code
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_FrozenAccountBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();
            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        //unit test method
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }
        }
    }
}

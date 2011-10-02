using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCPAL;

namespace WCPAL.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WoWPlatformTests
    {

        WoWPlatform wp;
        string testRealm = "Sentinels";
        List<String> testRealmList = new List<String>();
        

        
        public WoWPlatformTests()
        {
            wp = new WoWPlatform();
        }

        [TestInitialize]
        public void Init()
        {

        }



        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Realm Tests
        [TestMethod]
        public void GetSingleRealmStatus()
        {
            try
            {
                Realm r = wp.GetRealmStatus(testRealm);

                Assert.IsTrue(r.Name.Equals(testRealm), "Didn't return the correct realm");
                Assert.IsTrue(r.Type.Equals(RealmType.PVE), "Didn't return the correct realm type");
            }
            catch (BattlenetConnectionException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void GetMultipleRealmStatus()
        {

            testRealmList.Add(testRealm);
            testRealmList.Add("Sentinels");
            testRealmList.Add("Moon Guard");

            try
            {
                List<Realm> realms = (List<Realm>)wp.GetRealmStatus(testRealmList);

                Assert.IsTrue(realms[0].Name.Equals(testRealmList[0]), "First realm name is incorrect");
                Assert.IsTrue(realms[1].Type.Equals(RealmType.RP), "Second realm type is incorrect");
                Assert.IsTrue(realms[2].Slug.Equals("moon-guard"), "Third realm slug is incorrect");
            }
            catch (BattlenetConnectionException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllRealmStatus()
        {
            try
            {
                List<Realm> realms = (List<Realm>)wp.GetRealmStatus();

                Assert.IsTrue(realms.Count > 0, "Method did not return any realms");
                Realm r = realms.Find(x => x.Name == "Llane");
                Assert.IsTrue(r != null, "Method did not return a valid list of realms");
            }
            catch (BattlenetConnectionException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion
        
        #region Character Tests

        [TestMethod]
        public void SingleCharacterWithNoExtraData()
        {
            string testChar = "Daegren";
            string testRealm = "Sentinels";
            try
            {
                Character c = wp.GetCharacter(testChar, testRealm);

                Assert.IsTrue(c.Name == testChar, "Character name is not the same");

            }
            catch (BattlenetConnectionException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion
    }
}

 public string InsertContract(int country, string idno, string pageno,
        string registerno, int cityid, string fullname, int gender, int idtype, string palceofissue,
        string Town, string street, string houseno, string DateofBirth, string contractdate,
        string contactno, string msisdn, int subscriberID)
    {
        string result = "";

        try
        {
            DemoDB program = new DemoDB();
            Contracts contracts = new Contracts();
            contracts.ChanelID = 4;
            contracts.Bscsid = "1";
            contracts.IdNumber = idno;
            contracts.IdPageNo = pageno;
            contracts.IdRegisterNo = registerno;
            contracts.CityID = cityid;
            contracts.FirstName = fullname;
            contracts.GenderID = gender;
            contracts.CountryID = country;
            contracts.IdtypeID = idtype;
            contracts.IdPlaceOfIssue = palceofissue;
            contracts.Area = Town;
            contracts.Governorate = Town;
            contracts.Street = street;
            contracts.Houseno = houseno;
            contracts.DateOfBirth = DateofBirth;
            contracts.Contractdate = contractdate;
            contracts.AlternativePhoneNumber = contactno;
            contracts.IpAddress = "10.10.20.11";
            contracts.ReqUserid = Session["id"].ToString();
            contracts.ReqUserName = Session["name1"].ToString();
            contracts.Msisdn = msisdn;
            contracts.Subscriberid = subscriberID;
            contracts.PassportIssueDate = "";
            contracts.PassportExpDate = "";
            contracts.FoodRsidntNo = "";
            contracts.VisaRsdntIdNo = "";
            contracts.MotherName = "";
            contracts.FatherName = "";
            contracts.LastName = "";
            contracts.Email = "";
            contracts.NearestGuidePoint = "";
            contracts.Action = 2;
            string inhash = null;
            string strTempHash = idtype + idno + pageno + registerno + "K0rekE@TcrmDem0C0ntr@cts@@P@ssw0rd";
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                inhash = program.GetMd5Hash(md5Hash, strTempHash);
            }
            contracts.Hash = inhash.ToString();
            var response = program.PostContractAsync(contracts);
            if (response.Result.Status == 3)
            {
                result = response.Result.Notification.ToString();
                return result;
            }
            else if (response.Result.Status == 1)
            {
                result = response.Result.Notification.ToString();
                return result;
            }
            else if (response.Result.Status == -1)
            {
                result = response.Result.Notification.ToString();
                return result;
            }
            else
            {
                result = response.Result.Notification.ToString();
                Session["msisdn"] = msisdn;
                ///////Insert sim card sale transaction information //////// 
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }
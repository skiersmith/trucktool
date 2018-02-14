using System;

namespace keepr.Models
{
    public class Record
    {
        public int DOT { get; set; }
        public string DOCKET { get; set; }
        public string LAST_MODIFIED_DATE { get; set; }
        public string ENTITY_TYPE { get; set; }
        public string FMCSA_DBA { get; set; }
        public string CENSUS_LEGAL_NAME { get; set; }
        public string FMCSA_BUSINESS_TELEPHONE_NUMBER { get; set; }

        public string CENSUS_CELL_PHONE_NUMBER { get; set; }

        public string CENSUS_MAILING_ADDRESS_STATE { get; set; }

        public string LATEST_REVIEW_DATE { get; set; }

        public string SAFETY_RATING { get; set; }

        public string EMAIL_ADDRESS { get; set; }
        public string COMPANY_REP_1 { get; set; }
        public string COMPANY_REP_2 { get; set; }

        public string MCS_150_DATE { get; set; }
        public string MCS_150_MILEAGE_YEAR { get; set; }
        public string SAFER_OPERATING_STATUS { get; set; }
        public string VIOLATION { get; set; }
        public int userid { get; set; }
    }
}
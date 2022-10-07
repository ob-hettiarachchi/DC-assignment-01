namespace ServicePublishing
{
    class customer
    {
        // To create only one instance of the customer
        public customer() { }
        private static customer instance = null;
        public static customer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new customer();
                }
                return instance;
            }
        }



        private string name;
        private int token;



        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setToken(int token)
        {
            this.token = token;
        }
        public int getToken()
        {
            return this.token;
        }
    }
}

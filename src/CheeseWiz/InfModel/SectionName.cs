namespace CheeseWiz.InfModel
{
	public class SectionName
	{
		public string Type { get; private set; }

		public string Name { get; private set; }

		public bool HasType
		{
			get { return !string.IsNullOrEmpty(Type); }
		}

		public SectionName(string sectionName)
		{
			var split = sectionName.Split('.');
			if (split.Length > 1)
			{
				Type = split[0];
				Name = split[1];
			}
			else
				Name = sectionName;
		}

		public override string ToString()
		{
			string toString;
			if (!string.IsNullOrEmpty(Type))
				toString = string.Format("{0}.{1}", Type, Name);
			else
				toString = Name;
			return toString;
		}

		public static implicit operator string(SectionName sectionName)
		{
			return sectionName.ToString();
		}
	}
}
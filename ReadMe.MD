![YTG Logo](http://ytgi.com/images/ytgi.png)

# YTG-TempManager
<p>Yasgar Technology Group Temp folder management application</p>
<p>.NET 8.0</p>
<p>Console application utilizing dependency injection</p>
</br>

## Deploying
<p>This is a stand along EXE that requires the appsettings.json to be with it for the appropriate settings</p>

> ### NuGet Package

### Azure Pipeline
azure-YTGITEST02.yml - Kicks off build on next branch checkin to YTGITEST02.ytgi.net server
</br>

# Server Setup
## YTGITEST02

F:\WebDeploy\RV4US.ACCT.PROC<br />
App Pool: rv4us.acct.proc.api<br />
IIS: rv4us.acct.proc.api<br />
Bindings: <br />
|Type  |IP address |Port|Host                   |SNI| 
|:---  |:---|:---|:---|:---|
|HTTP  |*   |5065| |No|
|HTTPS |*   |443 |rv-acct-api-qa.rv4.us|Yes|
<br />

## YTGIPROD02
F:\WebDeploy\RV4US.ACCT.PROC<br />
F:\FTPRoot\Websites\RV4US.ACCT.PROC<br />
App Pool: RV4US.Acct.Proc<br />
IIS: RV4US.Acct.Proc<br />
Bindings: <br />
|Type  |IP address |Port|Host                |SNI| 
|:---  |:---|:---|:---|:---|
|HTTPS |*   |443 |rv-acct-api-prod2.rv4.us|Yes|
<br />

## DB Scaffolding for RVResearch schema items
<p><b>NOTE:</b> -NoOnConfiguring and -NoPluralize are for EF Core 5.0 and above only.</p>

Scaffold-DbContext "Server=localhost;Database=RVResearch;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables<br />
	"acct.DealerLeads",<br />
	"acct.Newsletters",<br />
	"lookups.LuCategories",<br />
	"lookups.LuItems",<br />
	"rvs.RVModels",<br />
	"rvs.Brands",<br />
	"rvs.Manufacturers",<br />
	"rvs.Features_Base",<br />
	"rvs.FunctionalBenefits",<br />
	"rvs.TopTenItems",<br />
    "rvs.Map_TopTen_Features",<br />
    "rvs.Map_TopTen_Functional",<br />
    "rvs.Map_TopTen_RVTypes",<br />
	"rvs.Uploads",<br />
	"tracking.TopTen_Filters",<br />
	"tracking.TopTen_Results",<br />
	"tracking.TopTen_Selects",<br />
	"tracking.Trad_Results",<br />
	"tracking.Trad_Selects" <br />
-ContextDir Context -Context RVAccountContext -NoOnConfiguring -Force -UseDatabaseNames -NoPluralize<br />

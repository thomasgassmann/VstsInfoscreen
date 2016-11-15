# VstsInfoscreen
A website to show information for Visual Studio Team Services.


## Configuration
The configuration of the VstsInfoscreen is made in the Web.config file. The following options can / should be adjusted before using it:


### GetBuildsTimeFrameForSucceededBuilds
- This option is used to select the timeframe in which builds are requested from VSTS. This option is of the .NET type "TimeSpan" and can be adjusted in the following format: 
>d.hh:mm:ss

### GetReleasesTimeFrameForSucceededReleases
- This option is used to select the timeframe in which releases are requested from VSTS. This option is of the .NET type "TimeSpan" and can be adjusted in the following format: 
>d.hh:mm:ss

### AccessToken
- This option is used for Authentication. A documentation on how to use Access Tokens in VSTS is found here:
https://www.visualstudio.com/en-us/docs/setup-admin/team-services/use-personal-access-tokens-to-authenticate

### Uri
- This is the default uri of the VstsInfoscreen. It should be in the following format:
> https://{yourtenant}.visualstudio.com

### BaseUri
- This is the VSTS uri including the Collection:
> https://{yourtenant}.visualstudio.com/{DefaultCollection}

### TeamProject
- The team project to get the information from.

### ApiBaseUri
- The API base uri should be in the following format:
> https://{yourtenant}.vsrm.visualstudio.com/{DefaultCollection}/{teamProject}

### CurrentIteration
- A value indicating whether to get the current iteration to show it in the Additional Information panel on top of the Infoscreen or not.
- The value should be a value parsable to "System.Bool"

### FailedBuildsLast7Days
- A value indicating whether to get the amount of failed builds in the last 7 days and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### SuccessfulBuildsLast7Days
- A value indicating whether to get the amount of successful builds in the last 7 days and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### OpenPullRequests
- A value indicating whether to get the amount of open pull requests and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### TeamDaysOff
- A value indicating whether to get the team days off and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### DaysOffAndCapacityPerPerson
- A value indicating whether to get the team days off and the capacity for each person and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### PullRequestsWithMergeConflicts
- A value indicating whether to get the amount of pull requests with merge conflicts and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### NewWorkItemCount
- A value indicating whether to get the amount of new work items and show in the Additional Information panel on top of the Infoscreen.
- The value should be a value parsable to "System.Bool"

### UpdateIterationsHour
- A value indicating when to update the iterations from VSTS. The value is an integer value indicating the hours it takes to wait until to reload the iterations. The following is the default value:
>12

### UpdateAdditionalInformation
- This property sets the interval to reload the additional information from the VstsInfoscreen. The value is formatted in milliseconds. The following is the default value:
>60000

### UpdateBuilds
- This property sets the interval to reload the builds from the VstsInfoscreen. The value is formatted in milliseconds. The following is the default value:
>10000

### UpdatePullRequests
- This property sets the interval to reload the pull requests from the VstsInfoscreen. The value is formatted in milliseconds. The following is the default value:
>10000

### UpdateReleases
- This property sets the interval to reload the releases from the VstsInfoscreen. The value is formatted in milliseconds. The following is the default value:
>10000

### CompactMode
- In Compact Mode the cards are smaller to give more place to more cards. With CompactMode turned off, more information will show up on the VstsInfoscreen. With CompactMode turned on more cards can be shown on the VstsInfoscreen.
- The value should be a value parsable to "System.Bool"

### SwitchCards
- With the SwitchCards property turned on, the cards displayed on the screen will be switched, so the information on the bottom of the website can be viewed without scrolling down. This feature is especially useful if compact mode is turned off. With CompactMode turned off and SwitchCards turned on there are more information to view and all cards can still be viewed because they're switched.
- The value should be a value parsable to "System.Bool"

### SwitchInterval
- The SwitchInterval property defines the interval it takes to switch a card. A SwitchInterval of "5000" for example will switch the cards every 5 seconds, if the SwitchCards property is turned on. This property is an integer value representing the time in milliseconds

### FailedReleasesLast7Days
- A value indicating whether to get the amount of failed releases in the last 7 days to show it in the Additional Information panel on top of the Infoscreen or not.
- The value should be a value parsable to "System.Bool"

### SuccessfulReleasesLast7Days
- A value indicating whether to get the amount of successful releases in the last 7 days to show it in the Additional Information panel on top of the Infoscreen or not.
- The value should be a value parsable to "System.Bool"

### CompletedPullRequestsLast7Days
- A value indicating whether to get the amount of completed pull requests in the last 7 days to show it in the Additional Information panel on top of the Infoscreen or not.
- The value should be a value parsable to "System.Bool"

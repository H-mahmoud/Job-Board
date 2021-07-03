# Job Board

Job Board is a Web App built with Asp.net Core to open a new opportunity for developers to find jobs.

### Features:
- A complete authentication system using Microsoft Identity
    - Login, Register, Reset Password and Email Confirmation
- User can view Jobs Details
- User can search for a job by Title, Category and/or Job Nature 
- Authenticated Users can update their profile information 

#### Admin:
- Accept or remove Pending Posts
- Create new Categories

#### Recruiter:
- Post a new job (Defualt status is pending)
- Delete his posted jobs
- View the information of job Candidates
- View his Posted Jobs

#### Developer:
- Can apply for any job.
- View his Applied Jobs

<hr>

* I am using MailJet to send emails to users

<hr>

### API Endponts:
#### Jobs
- [GET] /API/Job
- [GET] /API/Job/{Id}

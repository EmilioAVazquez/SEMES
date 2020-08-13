# SEMES

This project seeks to create a OpenSource Accounting System with a scalable backend and a stable frontend. This porject was originally created to tailor the needs of Semes, a company from Ecuator seeking to distribute potable water. 🇺🇳  Throught the United Nation this company's needs were brought to our sight and the opportunity to create an OpenSource Accounting system was born.

### United Nation Goas and Our Goals 🌎

Smartphone prolifaration  is not a phenomenon isolated for the developing world 📱. The Pew Research Center recorded an increment to 39% in 2018 from the 28% in 2015 among the population younger than 50 years old in Nigeria (https://www.pewresearch.org/global/2019/02/05/smartphone-ownership-is-growing-rapidly-around-the-world-but-not-always-equally/). It's then clear we should take advantage of this technological and social advacement. The question is then how to harvest this technological potential. Which of all the UN goals should we tackle first? Which market should we venture in? How can we help Semes in Ecuator? This is were Abhijit Banerjee and Esther Duflo come in. 💰 In 'Poor Economics', they suggest that new financial products  are key for lifting people out of poverty. Just like food and education, bank accounts and issurance can help in this as well. Our hope is that this product will do just that: contribute to the economic development of marginalized communities all around the globe by providing an autometed accounting service. 

This project seeks to contribute to financial services that the poor all arround the world can benefit from today. Small buisness owners in the develeloping world can use this service (free and automated) to keep track of their accounting as well as to get some key insight on their buisness. Our hope is that this project will unlock new possibilities to small buisness owners anywhere on earth. This story start with Semes🎉.

### How to to contribute?

🤓 We are building this project on a backend developed on Asp.net and the frontend is developed on React. When contributing please remember the many coonstrains that technology in the developing wolrd may suffer from. Low bandwidths, unrelaiable communication, and obsolete smartphones to name a few. Please join our Discord channel with any question, comment or complain. We want to create a community of developers that seek to help the world with code❤️.
 
https://discord.gg/9pMeby

To overcome some of the technical difficulties when developing applications on the developing world some key resources may help:

Android Go Edition 

This version of android arrived on 2018 with the focus of targetting emerging markets. Among the advantages of this operating system is the reduced size of the OS as well as memory optimezed apps that run on devices with less than 2GB of ram and a limited storage. Read the guidlines to develop on this OS.
https://developer.android.com/google-play/guides/android-go-edition

Progressive Web Apps

Aside from providing a light weight application, Progressive web apps also allow for the quick adoption of applications. We want to allow users to get their applications up and running as fast as possible. By simply following a link a user will be able to download a webapplication.
https://web.dev

### The key features of version 0.1 (as July 29th, 2020)

In this first iteration of this application we want to develop the system that the organization Semes needs. On it bear bones this application has to keep track of the items sold, its clients, and its suppliers. Together with Industrail Engineer Porras, Semes director, we came up with this first iteration most important features: 

1) Through a smartphone based web application, any Employer will be able to log in transactions.
2) All these collected data will be served to any Administartor in a digested manner (graphs and key values). 
3) Transactions will be verified by any Administartor.
4) Any Incoming Supply can be log and verified by any Administrator.
5) The key information of clients, suppliers, items, and products will be taken and made available to administrators.

### Steps to get this project running:

 Docker image: 🐳
 ```docker pull emilioavazquez/semes:0.0```
 
 Recommended Development guide: 
 After pulling the docker image.
 1) Select or create a directory to host this repo and  ```cd``` to it.
 2) Clone this repo.
   ```git clone https://github.com/EmilioAVazquez/SEMES.git```
 2) Create a docker container for webapp development.
 ```docker run --volume [Local Directory Path to Github Repo]:/home/project -p 3000:3000  -d -i emilioavazquez/semes bash```
 3) Create a docker container API development
 ```docker run --volume [Local Directory Path to Github Repo]:/home/project -p 5000:5000  -d -i emilioavazquez/semes bash```
 4) Start containers
  ```docker start [id of generated docker contianers]```
  ```docker start [id of generated docker contianers]```
 5) Bash to container  with ports mapped to 5000(from step 4). 
  ```docker exec -it [id of contianer mapped to port 5000] bin/bash```
 6) Start dotnet.
  ```cd home/project/src; dotnet build; dotnet run; exit;```
 7) Bash to contianer with ports mapped to  3000(from step 3).
  ```docker exec -it [id of contianer mapped to port 3000] bin/bash```
 8) Start npm.
 ```cd home/project/src;npm build; npm start;exit;```
 9) Bash to the contianer you want to develop in.
 10) Happy coding! 🎉


 ### App Demo:


 ![Alt text](demo.gif){:height="50%" width="50%"}
 









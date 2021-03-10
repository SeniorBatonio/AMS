db.createUser(
    {
        user: "amsadmin",
        pwd: "amsadmin",
        roles:[
            {
                role : "readWrite",
                db: "amsdb"
            }
        ]
    }
)
curl -X POST \
https://api.mailersend.com/v1/email \
-H 'Content-Type: application/json' \
-H 'X-Requested-With: XMLHttpRequest' \
-H 'Authorization: Bearer mlsn.bb37b15ec2103ee9026236694a22af21db5602a0b7985a1d9a46799b726c6fc5' \
-d '{
    "from": {
        "email": "dannyKentala@trial-jy7zpl9xp8ol5vx6.mlsender.net"
    },
    "to": [
        {
            "email": "handres41@outlook.com"
        }
    ],
    "subject": "Hello from MailerSend!",
    "text": "Greetings from the team, you got this message through MailerSend.",
    "html": "Greetings from the team, you got this message through MailerSend."
}'
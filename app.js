const express = require('express');
const app = express();
const port = 3000;


app.get('/users/:userId/books/:bookId', (req, res) => {
    res.send(req.params)
})

app.get('/', (req, res) => {
    res.send('Bienvenue sur votre API Express !');
});

app.listen(port, () => {
    console.log(`L'API est en écoute sur le port ${port}`);
});

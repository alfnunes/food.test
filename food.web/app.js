const environment = process.env.NODE_ENV || 'development';
const config = require(`./config/config.${environment}`);

const app = require('./config/server');

app.listen(config.api.port, () => console.log(`running at http://localhost:${config.api.port}`));
const bunyan = require('bunyan');
const BunyanRailtownAi = require('@railtownai/bunyan-railtownai');
var log = bunyan.createLogger({
  name: 'myapp',
  stream: new BunyanRailtownAi({
    token:
      'your_railtown_token',
  }),
});

const retrievePassport = () => {
  getPassport();
};

try {
  retrievePassport();
} catch (error){
  log.error(error);
}
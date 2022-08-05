const pino = require('pino');
const transportForRailtownai = pino.transport({
  target: '@railtownai/pino-railtownai',
  options: {
    token: 'your_railtown_token',
  },
});

const logger = pino(transportForRailtownai);
 
const retrievePassport = () => {
  getPassport();
};

try {
  retrievePassport();
} catch (error){
  logger.error(error);
}
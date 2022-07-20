const pino = require('pino');
const transportForRailtownai = pino.transport({
  target: '@railtownai/pino-railtownai',
  options: {
    token: 'your_railtown_token',
  },
});

const logger = pino(transportForRailtownai);
 
logger.error(new Error('An error occured.'));
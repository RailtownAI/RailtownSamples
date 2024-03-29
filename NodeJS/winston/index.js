const winston = require('winston');
const RailtownTransport = require('@railtownai/winston-railtownai');
const logger = winston.createLogger({
  transports: [
    new winston.transports.Console(),
    new winston.transports.File({ filename: 'combined.log' }),
  ],
});

logger.add(
  new RailtownTransport({
    token:
      'your_railtown_token',
  })
);

const retrievePassport = () => {
  getPassport();
};

try {
  retrievePassport();
} catch (error){
  logger.error(error);
}
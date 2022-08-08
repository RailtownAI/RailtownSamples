const log4js = require('log4js');

log4js.configure({
  appenders: {
    railtownai: {
      type: '@railtownai/log4js-railtownai',
      token: 'your_railtown_token',
    },
  },
  categories: { default: { appenders: ['railtownai'], level: 'error' } },
});

const logger = log4js.getLogger();

const retrievePassport = () => {
  getPassport();
};

try {
  retrievePassport();
} catch (error){
  logger.error(error);
}
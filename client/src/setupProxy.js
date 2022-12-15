const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "product",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7204',
        secure: false
    });

    app.use(appProxy);
};

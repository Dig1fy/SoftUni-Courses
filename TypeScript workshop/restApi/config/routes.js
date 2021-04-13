const router = require("../routes/");

module.exports = (app) => {
  app.use("/api/user", router.user);

  app.use("/api/origami", router.origami);

  app.use("*", (req, res, next) => {
    res.status(404);
    res.send("Something went wrong. Try again.");
  });
};

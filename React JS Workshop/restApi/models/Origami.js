const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const Model = mongoose.model;
const { String, ObjectId } = Schema.Types;

const origamiSchema = new Schema({
  description: {
    type: String,
    required: true,
  },

  author: {
    type: ObjectId,
    ref: "User",
  },
},
  { //We need this for sorting the data by date
    timestamps:
      { createdAt: 'createdOn' }
  });

module.exports = new Model("Origami", origamiSchema);

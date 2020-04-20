let { Repository } = require("./solution.js");
let assert = require("chai").assert;

describe("Parser", () => {
    let repo;
    let pros;
    beforeEach(() => {
        pros = {
            name: "string",
            age: "number",
            birthday: "object"
        };

        repo = new Repository(pros);
    })

    describe('constructor', () => {
        it('should initialize the class properly', () => {
            let x = {
                name: "Ivo",
                age: "30",
                birthday: "June"
            }
            let newRepo = new Repository(x)
            assert.deepEqual(repo.props, {
                name: "string",
                age: "number",
                birthday: "object"
            })
            assert.deepEqual(repo.id, undefined)
            assert.deepEqual(repo.count, 0)
            assert.deepEqual(typeof repo.props, 'object' )



            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let r = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

r.add(entity);
assert.deepEqual(typeof r.props, 'object')

            let l = new Repository()
            assert.deepEqual(l.pros, undefined)
            assert.deepEqual(l.id, undefined)
            assert.deepEqual(l.count, 0)
        })
    })
    describe('add', () => {
        it('should work correctly', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let e2 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            }

            assert.deepEqual(repo.add(entity), 0)
            assert.deepEqual(repo.add(entity), 1)
            assert.throw(() => repo.add(e2), Error, 'Property age is missing from the entity!')
            let e3 = {
                birthday: new Date(1998, 0, 7)
            }
            assert.throw(() => repo.add(e3), Error, 'Property name is missing from the entity!')
        })
    })
    describe('getId', () => {
        it('should work as expected', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            assert.throw(() => repo.getId(1), Error, 'Entity with id: 1 does not exist!')
            assert.deepEqual(repo.add(entity), 1)
            assert.deepEqual(repo.getId(1), {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            })

        })
    })
    describe('update', () => {
        it('Should work', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            assert.throw(() => repo.update(1), Error, "Entity with id: 1 does not exist!")

            let entity2 = {
                name: "G",
                age: 2,
                birthday: new Date('s', 0, 7)
            };
            repo.add(entity)
            repo.update(1, entity2)
            assert.deepEqual(repo.getId(1), {
                name: "G",
                age: 2,
                birthday: new Date('s', 0, 7)
            })

            assert.throw(()=>repo.update(1,2), Error, 'Property name is missing from the entity!')
            assert.throw(()=>repo.update(1,'2'), Error, 'Property name is missing from the entity!')
            assert.throw(()=>repo.update(1,''), Error, 'Property name is missing from the entity!')
            assert.throw(()=>repo.update(1,true), Error, 'Property name is missing from the entity!')
        })
    })
    describe('delete', () => {
        it('should work...somehow', () => {

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity);
            assert.deepEqual(repo.count, 2)

            assert.throw(() => repo.del(2), Error, "Entity with id: 2 does not exist!")
            assert.throw(() => repo.del(true), Error, "Entity with id: true does not exist!")
            assert.throw(() => repo.del(), Error, "Entity with id: undefined does not exist!")
            assert.throw(() => repo.del('f'), Error, "Entity with id: f does not exist!")

            repo.del(0)
            assert.deepEqual(repo.count, 1)
            assert.deepEqual(repo.getId(1), {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            })
        })
    })
    describe('xx', () => {
        it('xxx', () => {



            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let r = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            r.add(entity)


            let newe = {
                name: 2,
                age: "2",
                birthday: new Date(1998, 0, 7)
            };

            assert.throw(() => r.update(0, newe), TypeError, 'Property name is not of correct type')

            newe = {
                name: "qweqwewq",
                age: "2",
                birthday: new Date(1998, 0, 7)
            };

            assert.throw(() => r.update(0, newe), TypeError, 'Property age is not of correct type')

            newe = {
                name: "qweqwewq",
                age: 25,
                birthday: 2
            };

            assert.throw(() => r.update(0, newe), TypeError, 'Property birthday is not of correct type')
            assert.throw(() => r.update(true), Error, 'Entity with id: true does not exist!')
            assert.throw(() => r.update(), Error, 'Entity with id: undefined does not exist!')
            assert.throw(() => r.update(''), Error, 'Entity with id:  does not exist!')
        })
    })
    describe('gggg', () => {
        it('hh', () => {


            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let r = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            r.add(entity)
            assert.throw(() => r.add(2), Error, 'Property name is missing from the entity!')
            assert.throw(() => r.add(''), Error, 'Property name is missing from the entity!')
            assert.throw(() => r.add(' '), Error, 'Property name is missing from the entity!')
            assert.throw(() => r.add(true), Error, 'Property name is missing from the entity!')
            assert.throw(() => r.add("2"), Error, 'Property name is missing from the entity!')
            assert.throw(() => r.add({name:'2', age: 22 }), Error, 'Property birthday is missing from the entity!')

            assert.throw(()=> r.getId('gg'), Error, 'Entity with id: gg does not exist!')
            assert.throw(()=> r.getId(), Error, 'Entity with id: undefined does not exist!')
            assert.throw(()=> r.getId(''), Error, 'Entity with id:  does not exist!')
            assert.throw(()=> r.getId(true), Error, 'Entity with id: true does not exist!')
            assert.throw(()=> r.del(true), Error, 'Entity with id: true does not exist!')
            assert.throw(()=> r.del('ga'), Error, 'Entity with id: ga does not exist!')
            assert.throw(()=> r.del(), Error, 'Entity with id: undefined does not exist!')
            assert.throw(()=> r.del(''), Error, 'Entity with id:  does not exist!')




        })
    })
    describe('', () => {
        it('', () => {

        })
    })
    describe('', () => {
        it('', () => {

        })
    })
});

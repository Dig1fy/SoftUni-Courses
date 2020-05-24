export default {
    create(data) {
        return firebase.firestore().collection('articles').add(data);
    },
    getAll(){
        return firebase.firestore().collection('articles').get();
    },
    get(id) {
        return firebase.firestore().collection('articles').doc(id).get();
    },
    close(id){
        return firebase.firestore().collection('articles').doc(id).delete();
    },
    edit(id, data) {
        return firebase.firestore().collection('articles').doc(id).update(data);
    },
    
}
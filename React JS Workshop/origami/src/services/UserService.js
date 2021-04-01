export default class UserService {
  static login(username, password) {
    return fetch("http://localhost:9999/api/user/login", {
      method: "POST",
      body: JSON.stringify({
        username,
        password,
      }),
    }).then((x) => x.json());
  }
}

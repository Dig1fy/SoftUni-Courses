import React, { useState } from "react";
import PageLayout from '../../components/layout/layout'

const LoginPage = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();
  };

  return (
    <PageLayout>
      <h1>LOGINNNNNNNNNNN</h1>
      <form onSubmit={handleSubmit}>
        <title title="Login" />
        <input
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          label="Username"
          id="username"
        />
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          label="Password"
          id="password"
        />
        <button type="submit" title="Login" />
      </form>
    </PageLayout>
  );
};

export default LoginPage;

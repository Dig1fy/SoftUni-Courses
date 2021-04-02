import React, { useState } from 'react'
import styles from './register.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'

const RegisterPage = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    const [rePassword, setRePassword] = useState('')

    function handleSubmit(e) {
        e.preventDefault();
    }

    const changeUsername = (event) => {
        setUsername(event.target.value)
    }

    const changePassword = (event) => {
        setPassword(event.target.value)
    }

    const changeRePassword = (event) => {
        setRePassword(event.target.value)
    }

    return (
        <PageLayout>
            <Title title="Register" />
            <form className={styles.container} onSubmit={(e) => handleSubmit(e)}>
                <div>
                    <label htmlFor={"username"}>Username</label> <br></br>
                    <input value={"zzzz"} id="username" value={username} onChange={(e) => changeUsername(e)} />
                </div>
                <div>
                <label htmlFor={"password"}>Password</label> <br></br>
                    <input type="password" id="password" value={password} onChange={(e) => changePassword(e)} />
                </div>
                <div>
                <label htmlFor={"rePassword"}>Re-password</label> <br></br>
                    <input type="password" id="rePassword" value={rePassword} onChange={(e) => changeRePassword(e)} />
                </div>
                <div>
                    <SubmitButton buttonValue="Submit" />
                </div>
            </form>
        </PageLayout>
    )
}

export default RegisterPage
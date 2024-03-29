import React, { useState, useContext } from 'react'
import styles from './login.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'
import Input from '../../components/input/input'
import { useHistory } from 'react-router-dom'
import authenticate from '../../helper-functions/fetchRequests/authenticate'
import UserContext from '../../Context'

const LoginPage = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    let history = useHistory();
    const context = useContext(UserContext);


    const handleSubmit = async (e) => {
        e.preventDefault();
        let body = { username, password };

        let onSuccess = (user) => {
            context.logIn(user)
            history.push("/")
        }

        let onFailure = (e) => {
            console.log("ERROR: ", e);
        }

        await authenticate(
            "http://localhost:9999/api/user/login", body, onSuccess, onFailure)
    }

    return (

        <PageLayout>
            <Title title="Login" />
            <form className={styles.container} onSubmit={(e) => handleSubmit(e)}>
                <div>
                    <Input
                        labelContent="Username"
                        id="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div>
                    <Input
                        type="password"
                        labelContent="Password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div>
                    <SubmitButton buttonValue="Submit" />
                </div>
            </form>
        </PageLayout>
    )
}

export default LoginPage

//VERSION 2 - Class Component
// class LoginPage extends React.Component {
//     constructor(props) {
//         super(props)

//         this.state = {
//             username: '',
//             password: ''
//         }
//     }

//     changeUsername = (event) => {
//         this.setState({ username: event.target.value })
//     }

//     changePassword = (event) => {
//         this.setState({ password: event.target.value })
//     }

//     static contextType = UserContext;

//     handleSubmit = async (e) => {
//         let username = this.state.username;
//         let password = this.state.password;
//         e.preventDefault();
//         await authenticate(
//             "http://localhost:9999/api/user/login",
//             { username, password },
//             (user) => {
//                 this.context.logIn({user:user})
//                 //username: "sd", id: "606aeaa0b1c8992b48240b12"
//                 // console.log(user);
//                 this.props.history.push("/")
//             },
//             (e) => {
//                 console.log("ERROR: ", e);
//             })
//     }

//     render() {
//         return (

//             <PageLayout>
//                 <Title title="Login" />
//                 <form className={styles.container} onSubmit={(e) => this.handleSubmit(e)}>
//                     <div>
//                         <Input
//                             labelContent="Username"
//                             id="username"
//                             value={this.state.username}
//                             onChange={(e) => this.changeUsername(e)}
//                         />
//                     </div>
//                     <div>
//                         <Input
//                             type="password"
//                             labelContent="Password"
//                             id="password"
//                             value={this.state.password}
//                             onChange={(e) => this.changePassword(e)}
//                         />
//                     </div>
//                     <div>
//                         <SubmitButton buttonValue="Submit" />
//                     </div>
//                 </form>
//             </PageLayout>
//         )
//     }
// }

// export default LoginPage
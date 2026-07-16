import { useState } from 'react'
import Form from './components/form.tsx'
import './App.css'

function App() {

  return (
    <>
      <Form 
        action="/" 
        method="POST" 
        legend="Login" 
        inputs={[
          {
            id: 'username', 
            name: 'username', 
            type: 'text', 
            label: 'username', 
          }, 

          {
            id: 'password',
            name: 'password', 
            type: 'password', 
            label: 'password', 
          }
        ]}/> 
    </>
  )
}

export default App

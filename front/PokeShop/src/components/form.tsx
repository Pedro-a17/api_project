import React, { useState } from "react";

const url = 'http://localhost:5107/api/Login/login';

type LoginDto = {
  UserName: string;
  Password: string;
}

type FormProps = {
  action: string;
  method: 'GET' | 'POST';
  inputs: InputProps[];
  legend: string;
}

type InputProps = {
  name: string;
  id: string;
  type: 'text' | 'number' | 'password' | 'date' | 'radio' | 'range' | 'checkbox' | 'color' | 'email';
  label?: string;
  placeholder?: string;
}

function Form({ action, method, inputs, legend }: FormProps){
  const [formData, setFormData] = useState<Record<string, any>>({});

  const handleInputChange = (id: string, value: any) => {
    setFormData((previousFormData) => ({
      ...previousFormData,
      [id]: value,
    }))
  }

  const handleFormSubmit = (e: React.SubmitEvent) => {
    e.preventDefault();
    const dto:  LoginDto= {
      UserName: formData['username'],
      Password: formData['password']
    }

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(dto)
    })
      .then((response) => {
        return response.json().then((data) => {
          if (!response.ok) throw new Error(data.message || `Http error: ${response.status}`);
          console.log(data);
        })
      })
      .catch((error) => {
        console.error('Request error', error.message);
        return;
      })

      setFormData({});
  }

  return (
    <fieldset className="fieldset-style">

      <legend>
        {legend}
      </legend>

      <form className={"form-style"} action={action} method={method} onSubmit={handleFormSubmit}>

        {inputs.map((input) => {
          return (
            <div key={input.id}>

              <input 
                className="input-style" 
                type={input.type} 
                name={input.name} 
                id={input.id} 
                value={formData[input.id] ?? ''}
                placeholder={!input.placeholder ? '' : input.placeholder}
                onChange={(e) => handleInputChange(input.id, e.target.value)}
                size={12}
                />
              <label htmlFor={input.id}>
                {!input.label ? input.name : input.label}
              </label>

            </div>
          )
        })}

        <button type="submit" className="button-style">Send</button>
      </form>
    </fieldset>
  )
}

export default Form;
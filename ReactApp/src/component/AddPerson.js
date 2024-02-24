import Button from 'react-bootstrap/Button'
import { Container, Toast } from 'react-bootstrap'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Table from 'react-bootstrap/Table';
import React, { useEffect, useState } from 'react'
import Pagination from 'react-bootstrap/Pagination';

function AddPerson() {
    const handlesubmit = (e) => {
       
        e.preventDefault();
        let regobj= (Name,Age,PersonTypeID);

        fetch("https://my-json-server.typicode.com/m4ur1c1o86/codetest/persons", {
        method: "POST",
        headers:{'content-type': 'application/json'},
        body: JSON.stringify(regobj)
        }).then((res)=>{
            toast.success('Added Successfully')
        }).catch((err)=>{
            toast.error('Error on creation')
        });
    }

  return (
    <>
      <form>
      <div class="form-group">
      <label for="formName">Name</label>
      <input type="text" class="form-control" id="formName" placeholder="Name"></input>
        </div>
        
        <div class="form-group">
      <label for="formName">Age</label>
      <input type="text" class="form-control" id="formName" placeholder="Name"></input>
        </div>

        <div class="form-group">
      <label for="formName">Type</label>
      <input type="text" class="form-control" id="formName" placeholder="Name"></input>
        </div>

      </form>
    </>
  )
}

export default AddPerson

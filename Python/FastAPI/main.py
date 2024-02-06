import os
import railtownai

from fastapi import FastAPI


app = FastAPI()

railtown_api_key = os.environ.get("RAILTOWN_API_KEY")
railtownai.init(railtown_api_key)


@app.get("/")
async def root():
    try:
        raise ValueError("This is an error")
        return {"message": "Hello World"}
    except Exception as e:
        railtownai.log(e)
        return {"message": str(e)}

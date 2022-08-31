import cv2
import numpy as np

# image detection trained file
face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')
# video capture from camera
cap = cv2.VideoCapture(0)

# image isloation
def region(img, vertices):
    mask = np.zeros((img.shape[0],img.shape[1]))
    cv2.fillConvexPoly(mask, vertices, 1)
    mask = mask.astype(np.bool)
    out = np.zeros_like(img)
    out[mask]=img[mask]
    return out

# initial definition
roi_vert = [(0,0),(0,10),(10,10),(10,0)]

while cap.isOpened():
    # frame by frame capture
    _, img = cap.read()
    # image detection
    gray_img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    faces = face_cascade.detectMultiScale(gray_img, 1.1, 4)

    # drawing rectangles for easy visibility
   # for (x, y , w ,h) in faces:
    #    cv2.rectangle(gray_img, (x-20,y-20), (x + w+20, y + h+20), (255, 0 , 0), 3)
     #   cv2.rectangle(gray_img, (x, y), (x + w, y + h), (0, 255, 0), 3)
      #  roi_gray = gray_img[y:y+h, x:x+w]
       # roi_color = img[y:y+h, x:x+w] 

    # isolating detected image
    for (x,y,w,h) in faces:
        roi_vert = [
            (x-20,y-20),
            (x-20, y + h + 20),
            (x+w + 20,y+h+ 20),
            (x+w+ 20,y-20),
        ] 

    # crop the image using the isolation
    cropped_img = region(img, np.array(roi_vert, 'int32'))

    # Display the output
    cv2.imshow('img', cropped_img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# release the camera
cap.release()

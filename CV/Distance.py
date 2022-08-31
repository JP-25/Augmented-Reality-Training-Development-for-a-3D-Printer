import cv2
import numpy as np
import imutils

# Known variables
KNOWN_WIDTH = 8
KNOWN_FL = 1644.7664174397787 #1680.6998931884766 #1721.5691569010417 #1680.6998931884766 #1644.7664174397787
DTotal = 0
index = 0
distance = 0

# Mock Isolation
def region(img, vertices):
    mask = np.zeros((img.shape[0], img.shape[1]))
    cv2.fillConvexPoly(mask, vertices, 1)
    mask = mask.astype(np.bool)
    out = np.zeros_like(img)
    out[mask] = img[mask]
    return out

# Video Capture
cap = cv2.VideoCapture('vid84.mp4')

# while loop only runs for 15 good frames
while index<15:
    # taking the video frame by frame
    ret, img = cap.read()
    # correction for the last frame of a video
    if img is None:
        break
    # dimensions of the frame used to create a mock isolation
    img_height = img.shape[0]
    img_width = img.shape[1]
    # mock isolation
    vert = [
        (0.1 * img_width, 0.1 * img_height),
        (0.1 * img_width, 0.9 * img_height),
        (0.9 * img_width, 0.9 * img_height),
        (0.9 * img_width, 0.1 * img_height)
    ]
    # edge detection
    gray_img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    blur_img = cv2.GaussianBlur(gray_img, (5, 5), 0)
    edged_img = cv2.Canny(blur_img, 65, 120)
    cropped_img = region(edged_img, np.array(vert, 'int32'))
    # finding width of the largest visible closed contour
    cnts = cv2.findContours(cropped_img.copy(), cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
    cnts = imutils.grab_contours(cnts)
    choice = max(cnts, key=cv2.contourArea)
    area_choice = cv2.minAreaRect(choice)

    # distance calculation
    distance_old = distance
    distance = (KNOWN_WIDTH * KNOWN_FL) / area_choice[1][0]
    # ignores random spikes in value due to bad video quality
    if (distance < 2*distance_old) & (distance > 0.5*distance_old):
        print("new: ",distance)
        DTotal = DTotal + distance
        # index only changes for good values
        index = index + 1

    # draws a box for us to see whats going on
    box = cv2.cv.BoxPoints(area_choice) if imutils.is_cv2() else cv2.boxPoints(area_choice)
    box = np.int0(box)
    cv2.drawContours(img, [box], -1, (0, 255, 0), 2)
    cv2.imshow('img', img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# gives us a average value for the distance
Davg = DTotal/index
print("Distance avg: ", Davg)
# print("AC: ", area_choice[1][0])

cap.release()
import socket
import sys


print("Press enter to start posting")
msgFromClient       = input()

bytesToSend         = str.encode(msgFromClient)

UDP_IP = "127.0.0.1"
UDP_PORT = 7000

serverAddressPort   = ("127.0.0.1", 7000)

bufferSize          = 1024

# Create a UDP socket at client side
s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM, 0)
print("Type exit to exit program")
# Send to server using created UDP socket
while True:
	send_data = input("Type some text to send --> ");
	if send_data != 'Exit':
		s.sendto(send_data.encode('utf-8'), (UDP_IP,UDP_PORT))
	else: 
		sys.exit("Script stopped by user")

		
		
	


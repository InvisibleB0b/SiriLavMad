import socket





print("Insert Search word")

msgFromClient       = input()

bytesToSend         = str.encode(msgFromClient)

serverAddressPort   = ("127.0.0.1", 7000)

bufferSize          = 1024

# Create a UDP socket at client side
UDPClientSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)

# Send to server using created UDP socket
while True:
	if msgFromClient != "Exit":
		UDPClientSocket.sendto(bytesToSend, serverAddressPort);
		msgFromServer = UDPClientSocket.recvfrom(bufferSize);
		msg = msgFromClient.format(msgFromServer[0])
		print(msg)
	else:
		sys.exit("Script stopped by user")

		
		
	


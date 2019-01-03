### Project Description
This is a custom pipeline that enables you to :
- Receive an empty message 
- Route a message based on if the message entry is empty or not

### Custom pipeline properties :
DefaultMessage : this message is assigned to the message if and only if the entry message is empty    
ContextPropertyName, ContextPropertyNameSpace : you can put here a property that you want to promote, this property will take a boolean value that indicate if the entry message is empty or not. this property will serve us to route the empty message to the "trash send port"  

### How can i use it ?

Drag and Drop the custom pipeline in the decode stage 

Create a Property Schema With a property name "IsEmpty " for example

Set the Default Message value in the property editor 

Set the property name in the property editor 

Set the property namespace in the property editor 

This custom pipeline has been tested and used on prod heavily on FILE/FTP adapters (Microsoft and nSoftware)

### Note :

Since the property bag erases all the special char like CRLF, NULL...etc, you just have to put their equivalent hexa code.

That's it ! 

Additional information is available here: [Process Empty File](http://cherifmahieddine.com/2013/09/23/ignore-empty-message-biztalk/).

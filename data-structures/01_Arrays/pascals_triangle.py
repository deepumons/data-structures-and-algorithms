import array as arr

n = 5

pt = []

for i in range(n):   
    
    new = []
    
    for j in range(i+1):
        
        if(j == 0 or j == i):
            new.append(1)
        else:
            val = pt[i-1][j-1] + pt[i-1][j]            
            new.append(val)
            
    pt.append(new)    
    

for row in pt:
    print(row)
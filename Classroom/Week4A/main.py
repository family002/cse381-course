# CSE 381 REPL4A 
# Quick Sort
import random
import time
import statistics

def Sort(data):
    _Sort(data, 0, len(data)-1)

def _Sort(data, first,last):
    if first >= last: 
        return
    pivot = Partition(data, first, last)  
    _Sort(data, first, pivot - 1)
    _Sort(data, pivot + 1, last)

def Partition(data, first, last):
    lmgp = first
    pivot = random.randint(first, last)
    data[pivot], data[last] = data[last], data[pivot]
    for i in range(first, last):
        if data[i] <= data[last]:
            data[i] , data[lmgp] = data[lmgp], data[i]
            lmgp += 1
    data[lmgp], data[last] = data[last], data[lmgp]
    return lmgp

# data = [6,1,3,7,2,5,8,4]
# Sort(data)
# print(data)

def test_speed(num_trials=100, data_size=1000):
    times = []
    for _ in range(num_trials):
        data = [random.randint(0, 10000) for _ in range(data_size)]
        start = time.perf_counter()
        Sort(data)
        end = time.perf_counter()
        times.append(end - start)
    
    avg_time = statistics.mean(times)
    std_dev = statistics.stdev(times)
    
    print(f"Average sorting time over {num_trials} trials: {avg_time:.6f} seconds")
    print(f"Standard deviation: {std_dev:.6f} seconds")

    # Optional reliability note
    if std_dev > avg_time * 0.5:
        print("⚠️  The information may be unreliable due to high variation in run times.")
    
    return avg_time, std_dev

# Run test
if __name__ == "__main__":
    test_speed(num_trials=200, data_size=8000)
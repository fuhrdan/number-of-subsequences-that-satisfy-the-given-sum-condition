//*****************************************************************************
//** 1498. Number of Subsequences That Satisfy the Given Sum Condition       **
//**                                                                leetcode **
//*****************************************************************************

/*

int numSubseq(int* nums, int numsSize, int target) {
    long long count = 0;
    for(int i = 0; i < numsSize; i++)
    {
        for(int j = i; j < numsSize; j++)
        {
            if(nums[i] + nums[j] <= target) 
            {
                count = count + 1;
                printf("Count increased to %d at %d and %d\n",count,i,j);
            }
        }
    }
    if(nums[numsSize-1] <= target) count = count + 1;
    return count;

}

*/

#define MOD 1000000007

int compare(const void* a, const void* b)
{
    return (*(int*)a - *(int*)b);
}

int numSubseq(int* nums, int numsSize, int target)
{
    qsort(nums, numsSize, sizeof(int), compare);

    int* pow2 = (int*)malloc(sizeof(int) * numsSize);
    pow2[0] = 1;
    for(int i = 1; i < numsSize; i++)
    {
        pow2[i] = (pow2[i - 1] * 2) % MOD;
    }

    int left = 0;
    int right = numsSize - 1;
    long long count = 0;

    while(left <= right)
    {
        if(nums[left] + nums[right] <= target)
        {
            count = (count + pow2[right - left]) % MOD;
            left++;
        }
        else
        {
            right--;
        }
    }

    free(pow2);
    return (int)count;
}
# cd ./4.\ Deploy/Dashboard
# echo ">>>>> Destroy Dashboard and Deploy..."
# ./tf.sh destroy -auto-approve

cd ./4.\ Deploy/APIs
echo ">>>>> Destroy APIs and Deploy..."
./tf.sh destroy -auto-approve

cd ../../3.\ SQL_Server_Public/
echo ">>>>> Destroy SQL Server..."
./tf.sh destroy -auto-approve

cd ../2.\ Network/
echo ">>>>> Destroy Network..."
./tf.sh destroy -auto-approve

cd ../1.\ Main/
echo ">>>>> Destroy Main Reasources..."
./tf.sh destroy -auto-approve